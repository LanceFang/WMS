
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-18T20:33:17. All Rights Reserved.
//<生成时间>2017-04-18T20:33:17</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BM.WMS.WMS.Warehouses;

namespace BM.WMS.WMS.Warehouses.Dtos
{
	/// <summary>
    /// 库房信息列表Dto
    /// </summary>
    [AutoMapFrom(typeof(StoreInfo))]
    public class StoreInfoListDto : EntityDto<System.Guid>
    {
        /// <summary>
        /// 库房编号
        /// </summary>
        [DisplayName("库房编号")]
        public      string StoreCode { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        [DisplayName("库房名称")]
        public      string StoreName { get; set; }
        /// <summary>
        /// 仓库管理员
        /// </summary>
        [DisplayName("仓库管理员")]
        public      string UserName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public      string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
