// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-18T20:33:33. All Rights Reserved.
//<生成时间>2017-04-18T20:33:33</生成时间>
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace BM.WMS.WMS.Warehouses
{
    /// <summary>
    /// 库房信息业务管理
    /// </summary>
    public class StoreInfoManage : IDomainService
    {
        private readonly IRepository<StoreInfo,System.Guid> _storeInfoRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public StoreInfoManage(IRepository<StoreInfo,System.Guid> storeInfoRepository  )
        {
            _storeInfoRepository = storeInfoRepository;
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
