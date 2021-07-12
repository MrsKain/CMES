using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Siemens.SimaticIT.SystemData.Domain;
using Siemens.SimaticIT.SystemData.Domain.EventHandlerCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Linq;
using System.Reflection;
using Cnty.Core.EFDbContext;
using Microsoft.EntityFrameworkCore;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Core.Extensions.AutofacManager;
using System.Collections.Generic;
using Cnty.Core.Configuration;
using System.Runtime.Loader;
using Cnty.Core.Services;
using Cnty.Core.ObjectActionValidator;
using Cnty.Core.ManageUser;

namespace Cnty.Framework.Extension
{
    public class IOCContainer
    {
        //public static IContainer Container { get; set; }
        private static string platform = Environment.OSVersion.Platform.ToString();
        public static Action<ContainerBuilder> ContainerBuilderAction = ContainerBuilderCallBack;
        private static void ContainerBuilderCallBack(ContainerBuilder container)
        {

        }

        public static IServiceProvider BuildProvider(IServiceCollection service)
        {
            var builder = new ContainerBuilder();
            BuildContainer(builder, service);
            IContainer bulid = builder.Build();
            var provider = new AutofacServiceProvider(bulid);
            //#if DEBUG
            ///领域事件全局注入目前还在优化中，可以使用
            EventBus.Default.RegisterAllEventHandlerFromAssembly(provider, builder);
            // #endif
            return provider;
        }

        public static void BuildContainer(ContainerBuilder builder, IServiceCollection service)
        {
            builder.Populate(service);
            Type baseType = typeof(IDependency);
            var compilationLibrary = DependencyContext.Default
                .CompileLibraries
                .Where(x => !x.Serviceable
                && x.Type == "project")
                .ToList();
            var count1 = compilationLibrary.Count;
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (var _compilation in compilationLibrary)
            {
                try
                {
                    assemblyList.Add(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilation.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(_compilation.Name + ex.Message);
                }
            }
            builder.RegisterAssemblyTypes(assemblyList.ToArray())
             .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
             .AsSelf().AsImplementedInterfaces()
             .InstancePerLifetimeScope();
            builder.RegisterType<UserContext>().InstancePerLifetimeScope();
            builder.RegisterType<ActionObserver>().InstancePerLifetimeScope();
            //model校验结果
            builder.RegisterType<ObjectModelValidatorState>().InstancePerLifetimeScope();
            //Container = builder.Build();

            //加载非默认服务
            ContainerBuilderAction(builder);

        }

        private static System.Collections.Generic.List<Assembly> GetPlatform(string platform)
        {
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            var assemblys = (from name in runtimeAssemblyNames
                             where (name.FullName.StartsWith("Cnty") || name.FullName.StartsWith("Siemens") || name.FullName.StartsWith("SimaticIT"))
                             select Assembly.Load(name)).ToList();
            return assemblys;
        }
    }
}
