using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Cnty.Order.Repositories;
using Cnty.Core.BaseProvider;
using Cnty.Entity.DomainModels;
using Cnty.Order.IRepositories;
using Cnty.Core.Controllers.Basic;
using Cnty.Order.IServices;
using Cnty.Core.EFDbContext;
using Cnty.Core.DBManager;
using Cnty.Core.Extensions.AutofacManager;

namespace Cnty_QuartzNet_Demo.Jobs
{
    public class CntyDemoJob :IJob
    {
        private readonly ILogger _logger;

        private ISellOrderRepository _SellOrderRepository { get; set; }
        public CntyDemoJob(ILoggerFactory loggerFactory, ISellOrderRepository SellOrderRepository)
        {
            _logger = loggerFactory.CreateLogger<CntyDemoJob>();
            _SellOrderRepository = SellOrderRepository;

        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation("任务执行");
                DoAction();
                _logger.LogInformation("任务结束");
            }
            catch (Exception ex)
            {
                _logger.LogError("CntyDemoJob" + ex.Message);
            }
            await Task.CompletedTask;
        }


        public void DoAction()
        {
            try
            {
                Console.WriteLine("任务开始执行");
                //逻辑方法
                var demoData = _SellOrderRepository.Find(k=>k.IsDelete==0);
                Console.WriteLine("任务执行结束");
            }
            catch (Exception ex)
            {
                _logger.LogError("DoAction" + ex.Message);
            }
        }

    
    }
}
