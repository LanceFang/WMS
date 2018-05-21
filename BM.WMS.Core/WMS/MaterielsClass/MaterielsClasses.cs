using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;

namespace BM.WMS.MaterielsClass
{
    /// <summary>
    /// 物料分类
    /// </summary>
    [Table("MaterielsClasses")]
    public class MaterielsClasses : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 物料分类编号
        /// </summary>
        [Required]
        [StringLength(WMSConsts.MaxCodeLength)]
        public string ClassCode { get; set; }

        /// <summary>
        /// 物料分类名称
        /// </summary>
        [Required]
        public string ClassName { get; set; }

        public virtual int? TenantId { get; set; }

        public string Remark { get; set; }

        public bool IsEnable { get; set; }

        public MaterielsClasses()
        {

        }

        public MaterielsClasses(int? tentantId, string classCode, string className)
        {
            TenantId = tentantId;
            ClassCode = classCode;
            ClassName = ClassName;
        }
    }
}
