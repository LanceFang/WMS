using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using BM.WMS.Authorization.Users;

namespace BM.WMS.WMS.Warehouses
{
    /// <summary>
    /// 库房信息
    /// </summary>
    [Table("StoreInfo")]
    public class StoreInfo : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 库房编号
        /// </summary>
        [Required]
        public string StoreCode { get; set; }

        /// <summary>
        /// 库房名称
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// 库房地点
        /// </summary>
        public string StoreAddress { get; set; }

        /// <summary>
        /// 仓库管理员
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 仓库管理员
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 仓库管理员
        /// </summary>
        public string UserName { get; set; }

        public string Remark { get; set; }

        public int? TenantId { get; set; }

    }
}
