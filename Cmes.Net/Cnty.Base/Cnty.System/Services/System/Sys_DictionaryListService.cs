﻿/*
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using Cnty.System.IRepositories;
using Cnty.System.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Services
{
    public partial class Sys_DictionaryListService : ServiceBase<Sys_DictionaryList, ISys_DictionaryListRepository>, ISys_DictionaryListService, IDependency
    {
        public Sys_DictionaryListService(ISys_DictionaryListRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_DictionaryListService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_DictionaryListService>(); }
        }
    }
}

