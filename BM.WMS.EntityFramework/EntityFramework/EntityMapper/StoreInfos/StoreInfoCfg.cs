 // 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-18T20:33:39. All Rights Reserved.
//<生成时间>2017-04-18T20:33:39</生成时间>
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using BM.WMS.WMS.Warehouses;

namespace BM.WMS.WMS.Warehouses.EntityMapper.Warehouses
{

	/// <summary>
    /// 库房信息的数据配置文件
    /// </summary>
    public class StoreInfoCfg : EntityTypeConfiguration<StoreInfo>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "WMSDbContext" /> ]
        /// </summary>
		public StoreInfoCfg ()
		{
		            ToTable("StoreInfo", WMSConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到WMSDbContext中

  //		public IDbSet<StoreInfo> StoreInfos { get; set; }
   //		 modelBuilder.Configurations.Add(new StoreInfoCfg());




		    // 库房编号
			Property(a => a.StoreCode).HasMaxLength(4000);
		    // 库房名称
			Property(a => a.StoreName).HasMaxLength(4000);
		    // 库房地点
			Property(a => a.StoreAddress).HasMaxLength(4000);
		    // 仓库管理员 - 关系映射
			HasRequired(a => a.User).WithMany().HasForeignKey(c => c.UserId).WillCascadeOnDelete(true);


		    // 仓库管理员
			Property(a => a.UserName).HasMaxLength(4000);
		    // 备注
			Property(a => a.Remark).HasMaxLength(4000);
		}
    }
}