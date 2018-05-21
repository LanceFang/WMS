using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace BM.WMS.Customerses
{
    [Table("Customers")]
    public class Customers : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 客户编码
        /// </summary>
        [Required]
        [StringLength(WMSConsts.MaxCodeLength)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        [Required]
        [StringLength(WMSConsts.MaxCodeLength)]
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Required]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [RegularExpression(WMSConsts.TelNumber)]
        public string ContactTel { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        [RegularExpression(WMSConsts.PhoneNumber)]
        public string PhoneNum { get; set; }


        public int? TenantId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区、县
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

    }
}
