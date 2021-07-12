using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Cnty.Core.EFDbContext;
using Cnty.Order.IRepositories;
using Cnty.Order.IServices;
using Cnty.Order.Repositories;
using Cnty.WebApi;

namespace Cnty_Demo
{
    class Program
    {
        private static VOLContext dbContext=new VOLContext();
        private static SellOrderRepository _service = new SellOrderRepository(dbContext);
        
        static void Main(string[] args)
        {
           
            //var a = _service.GetEntityList();
            var a = _service.Find(k=>k.IsDelete==0);
            Console.WriteLine("Hello World!");
        }

      
    }
}
