using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace BM.WMS.MaterielsManage
{
    /// <summary>
    /// 物料信息业务管理
    /// </summary>
    public class MaterielsManage : IDomainService
    {
        private readonly IRepository<Materiels, System.Guid> _materielsRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterielsManage(IRepository<Materiels, System.Guid> materielsRepository)
        {
            _materielsRepository = materielsRepository;
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
