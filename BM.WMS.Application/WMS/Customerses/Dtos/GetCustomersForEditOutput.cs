using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using BM.WMS.Customers;

namespace BM.WMS.Customerses.Dtos
{
    /// <summary>
    /// 用于添加或编辑 客户资料管理时使用的DTO
    /// </summary>

    public class GetCustomersForEditOutput
    {
        /// <summary>
        /// Customers编辑状态的DTO
        /// </summary>
        public CustomersEditDto Customers { get; set; }


    }
}
