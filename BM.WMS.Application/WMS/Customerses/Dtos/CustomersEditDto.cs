using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.Customers;

namespace BM.WMS.Customerses.Dtos
{
    /// <summary>
    /// 客户资料管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(Customers))]
    public class CustomersEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        [DisplayName("客户编码")]
        [Required]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        [DisplayName("客户全称")]
        [Required]
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        [DisplayName("客户简称")]
        public string ShortName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DisplayName("联系人")]
        [Required]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [DisplayName("联系人电话")]
        public string ContactTel { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        [DisplayName("联系人手机号")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [DisplayName("省")]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [DisplayName("市")]
        public string City { get; set; }

        /// <summary>
        /// 区、县
        /// </summary>
        [DisplayName("区、县")]
        public string Area { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DisplayName("详细地址")]
        public string Address { get; set; }

    }
}
