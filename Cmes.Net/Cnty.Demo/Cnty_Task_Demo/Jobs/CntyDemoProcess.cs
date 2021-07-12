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
using Microsoft.Extensions.Hosting;
using System.Threading;

namespace Cnty_Task_Demo.Jobs
{
    /*
     1.Task 任务 模板项目；
     2.适用及时服务项目，频率在秒级别的服务。适用于：PLC读取，AVI过点等
     */
    public class CntyDemoProcess : IHostedService
    {
        private readonly ILogger _logger;
        private ISellOrderRepository _SellOrderRepository { get; set; }
        public CntyDemoProcess(ILoggerFactory loggerFactory, ISellOrderRepository SellOrderRepositor)
        {
            _logger = loggerFactory.CreateLogger<CntyDemoProcess>();
            _SellOrderRepository = SellOrderRepositor;
        }
        private IList<Task> tasks = new List<Task>();
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Task服务启动成功");
                //DoAction();//同步调试
                Task taskSendData = new Task(async () => await DoAction());
                taskSendData.Start();
                tasks.Add(taskSendData);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Task服务启动失败，错误消息：{ex.Message}");
            }
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Task服务停止应用");
            await Task.CompletedTask;
        }


        private async Task DoAction()
        {
            while (true)
            {
                DoTask();
                await Task.CompletedTask;
                Thread.Sleep(5000);

            }
        }


        public void DoTask()
        {
            try
            {
                Console.WriteLine("任务开始执行");
                //逻辑方法
                var demoData = _SellOrderRepository.Find(k => k.IsDelete == 0);
                Console.WriteLine("任务执行结束");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return;
            }
        }


    }
}
