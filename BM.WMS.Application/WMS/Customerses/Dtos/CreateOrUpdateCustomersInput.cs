using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.Customers;

namespace BM.WMS.Customerses.Dtos
{
    /// <summary>
    /// 客户资料管理新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateCustomersInput  
    {
    /// <summary>
    /// 客户资料管理编辑Dto
    /// </summary>
		public CustomersEditDto  CustomersEditDto {get;set;}
 
    }
}
