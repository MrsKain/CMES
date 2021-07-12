using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzExtensions
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            services.AddOptions();
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton((provider) =>
            {
                var option = provider.GetService<IOptions<QuartzOption>>().Value;
                var sf = new StdSchedulerFactory(option.ToProperties());
                var scheduler = sf.GetScheduler().GetAwaiter().GetResult();
                scheduler.JobFactory = provider.GetService<IJobFactory>();
                return scheduler;
            });

            services.AddHostedService<QuartzHostedService>();

            return services;
        }
    }
}
