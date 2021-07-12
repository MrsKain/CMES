
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cnty.Core.AppSettingsOption;
using Cnty.Framework.Extension;
using Cnty_QuartzNet_Demo.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using QuartzExtensions;
using System;
using System.Text;
using Topshelf;
using Cnty.Core.Configuration;
using Cnty.Core.EFDbContext;
using Cnty.Core.Extensions;
using Cnty.Order.Repositories;

namespace Cnty_QuartzNet_Demo
{
    /*
     1.QuartzNet 模板项目；
     2.适用定期执行的任务，比如 数据沉淀，数据迁移，频率超过10分钟以上的任务
     */
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Server Starting....");
                HostFactory.Run(x =>
                {
                    x.Service<IHost>(s =>
                    {
                        s.ConstructUsing(() => CreateHostBuilder(args).Build());
                        s.WhenStarted(service =>
                        {
                            service.Start();
                        });
                        s.WhenStopped(service =>
                        {
                            service.StopAsync();
                        });
                    });

                    x.StartAutomatically();
                    x.RunAsLocalSystem();

                    x.SetServiceName("Cnty_QuartzNet_Demo");
                    x.SetDisplayName("Cnty_QuartzNet_Demo");
                    x.SetDescription("Cnty模板测试项目");
                });
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("Main").Log(LogLevel.Error, ex);
                throw ex;
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = new HostBuilder()
                .UseConsoleLifetime()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //引入Nlog配置文件
                    //hostingContext.HostingEnvironment.ConfigureNLog(@"App_Data\config\Nlog.config");
                    NLogBuilder.ConfigureNLog(@"App_Data\config\Nlog.config");
                    hostingContext.HostingEnvironment.ApplicationName = "Cnty_QuartzNet_Demo";
                    hostingContext.HostingEnvironment.ContentRootPath = AppDomain.CurrentDomain.BaseDirectory;
                    var env = hostingContext.HostingEnvironment;
                    var basePath = $@"{ AppDomain.CurrentDomain.BaseDirectory}App_Data\config";
                    config
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .UseNLog()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>((hostingContext, container) =>
               {
                   var services = new ServiceCollection();
                   Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                   services.AddConfig(hostingContext.Configuration);
                   services.AddSingleton<CntyDemoJob>();
                   //services.AddSingleton<RpbiOrdercostJob>();
                   //services.AddSingleton<RpbiConsumablesInfoJob>();
                   //services.AddSingleton<RpbiConsumablesSummaryJob>();
                   services.AddQuartz();
                   IOCContainer.BuildContainer(container, services);
               });
            return host;
        }
    }

    static class ConfigExtensions
    {
        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<QuartzOption>(configuration.GetSection("quartz"));
            AppSetting.InitHostService(services, configuration);
        }
    }
}
