using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace BM.WMS.MaterielsClass
{
    /// <summary>
    /// 物料分类业务管理
    /// </summary>
    public class MaterielsClassesManage : IDomainService
    {
        private readonly IRepository<MaterielsClasses, System.Guid> _materielsClassesRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterielsClassesManage(IRepository<MaterielsClasses, System.Guid> materielsClassesRepository)
        {
            _materielsClassesRepository = materielsClassesRepository;
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
