using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Siemens.SimaticIT.SystemData.Domain;
using Siemens.SimaticIT.SystemData.Domain.EventHandlerCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Linq;
using System.Reflection;

namespace Siemens.SimaticIT.Extensions
{
    public class IOCContainer
    {
        //public static IContainer Container { get; set; }
        private static string platform = Environment.OSVersion.Platform.ToString();
        public static Action<ContainerBuilder> ContainerBuilderAction = ContainerBuilderCallBack;
        private static void ContainerBuilderCallBack(ContainerBuilder container){
           
        }

        public static IServiceProvider BuildProvider(IServiceCollection service)
        {
            var builder = new ContainerBuilder();
            BuildContainer(builder, service);  
            IContainer bulid = builder.Build();
            var provider=  new AutofacServiceProvider(bulid);
         //#if DEBUG
            ///领域事件全局注入目前还在优化中，可以使用
            //EventBus.Default.RegisterAllEventHandlerFromAssembly(provider, builder);
         // #endif
            return provider;
        }

        public static void BuildContainer(ContainerBuilder builder, IServiceCollection service)
        {
            builder.Populate(service);
            //builder.RegisterType<DbContext>().As<IDbContext>().InstancePerLifetimeScope();
          
            System.Collections.Generic.List<Assembly> assemblys = GetPlatform(platform);

            //var baseType = typeof(IDependency);
            //var baseSingleType = typeof(ISingleDependency);
            Type baseHandlerType = typeof(IEventHandler);

            //builder.RegisterAssemblyTypes(assemblys.ToArray())
            //.Where(c => baseType.IsAssignableFrom(c) && c != baseType)
            //.AsImplementedInterfaces()
            //.InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(assemblys.ToArray())
            //   .Where(c => baseSingleType.IsAssignableFrom(c) && c != baseSingleType)
            //   .AsImplementedInterfaces()
            //   .SingleInstance();

            ///注入领域事件
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(c =>
            baseHandlerType.IsAssignableFrom(c) && !c.IsAbstract)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
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
