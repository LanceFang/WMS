using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using BM.WMS.MaterielsManage;

namespace BM.WMS.EntityFramework.EntityMapper.Materielses
{

    /// <summary>
    /// 物料表的数据配置文件
    /// </summary>
    public class MaterielsCfg : EntityTypeConfiguration<Materiels>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "WMSDbContext" /> ]
        /// </summary>
        public MaterielsCfg()
        {
            ToTable("Materiels", WMSConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到WMSDbContext中
            //public IDbSet<Materiels> Materielss { get; set; }
            //modelBuilder.Configurations.Add(new MaterielsCfg());

            // MaterielsClass - 关系映射
            HasRequired(a => a.MaterielsClass).WithMany().HasForeignKey(c => c.MaterialClassId).WillCascadeOnDelete(true);

            // 物料简码
            Property(a => a.ShortCode).HasMaxLength(50);
            // MaterialCode
            Property(a => a.MaterialCode).HasMaxLength(50);
            // MaterialName
            Property(a => a.MaterialName).HasMaxLength(50);
            // 物料全称
            Property(a => a.FullName).HasMaxLength(100);
            // 助记码
            Property(a => a.HelperCode).HasMaxLength(50);
            // Model
            Property(a => a.Model).HasMaxLength(50);
            // 单位
            Property(a => a.Unit).HasMaxLength(50);
            // 备注
            Property(a => a.Remark).HasMaxLength(200);
        }
    }
}