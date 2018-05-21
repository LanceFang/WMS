using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using BM.WMS.MaterielsClass;

namespace BM.WMS.EntityFramework.EntityMapper.MaterielsClass
{
    /// <summary>
    /// 物料分类的数据配置文件
    /// </summary>
    public class MaterielsClassesCfg : EntityTypeConfiguration<MaterielsClasses>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "WMSDbContext" /> ]
        /// </summary>
        public MaterielsClassesCfg()
        {
            ToTable("MaterielsClasses", WMSConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到WMSDbContext中

            //		public IDbSet<MaterielsClasses> MaterielsClassess { get; set; }
            //		 modelBuilder.Configurations.Add(new MaterielsClassesCfg());

            // 物料分类编号
            Property(a => a.ClassCode).HasMaxLength(8);
            // 物料分类名称
            Property(a => a.ClassName).HasMaxLength(50);
            // 备注
            Property(a => a.Remark).HasMaxLength(200);
        }
    }
}