using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using BM.WMS.MaterielsClass;

namespace BM.WMS.MaterielsManage
{
    /// <summary>
    /// 物料信息
    /// </summary>

    [Table("Materiels")]
    public class Materiels : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public MaterielsClasses MaterielsClass { get; set; }

        public Guid MaterialClassId { get; set; }

        public string ClassName { get; set; }

        public int? TenantId { get; set; }

        /// <summary>
        /// 物料简码
        /// </summary>
        public string ShortCode { get; set; }

        [Required]
        [StringLength(WMSConsts.MaxCodeLength)]
        [RegularExpression(WMSConsts.MaterielsCodeRegex)]
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }


        [Required]
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 物料全称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        public string HelperCode { get; set; }

        [Required]
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
