
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-18T20:33:15. All Rights Reserved.
//<生成时间>2017-04-18T20:33:15</生成时间>
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.WMS.Warehouses;

namespace BM.WMS.WMS.Warehouses.Dtos
{
    /// <summary>
    /// 库房信息编辑用Dto
    /// </summary>
    [AutoMap(typeof(StoreInfo))]
    public class StoreInfoEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public System.Guid? Id{get;set;}

        /// <summary>
        /// 库房编号
        /// </summary>
        [DisplayName("库房编号")]
        [Required]
        public   string  StoreCode { get; set; }

        /// <summary>
        /// 库房名称
        /// </summary>
        [DisplayName("库房名称")]
        [Required]
        public   string  StoreName { get; set; }

        /// <summary>
        /// 库房地点
        /// </summary>
        [DisplayName("库房地点")]
        public   string  StoreAddress { get; set; }

        /// <summary>
        /// 仓库管理员
        /// </summary>
        [DisplayName("仓库管理员")]
        public   int  UserId { get; set; }

        /// <summary>
        /// 仓库管理员
        /// </summary>
        [DisplayName("仓库管理员")]
        [Required]
        public   string  UserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public   string  Remark { get; set; }

    }
}
