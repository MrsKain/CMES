using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzExtensions
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        public JobFactory(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<JobFactory>(); ;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                var job = _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
                if (job==null) {
                    _logger.LogError($"{bundle.JobDetail.JobType} create error");
                }
                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{bundle.JobDetail.JobType} {ex.StackTrace} create error");
            }
            return null;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
