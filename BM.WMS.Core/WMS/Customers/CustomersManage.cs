using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace BM.WMS.Customerses
{
    /// <summary>
    /// 客户资料管理业务管理
    /// </summary>
    public class CustomersManage : IDomainService
    {
        private readonly IRepository<Customers, System.Guid> _customersRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CustomersManage(IRepository<Customers, System.Guid> customersRepository)
        {
            _customersRepository = customersRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {




        }


    }



}
