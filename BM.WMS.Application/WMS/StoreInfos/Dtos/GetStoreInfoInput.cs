using System;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using BM.WMS.WMS.Warehouses.Dtos;
using BM.WMS.WMS.Warehouses;
using BM.WMS.Dto;

namespace BM.WMS.WMS.Warehouses.Dtos
{
	/// <summary>
    /// 库房信息查询Dto
    /// </summary>
    public class GetStoreInfoInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

		/// <summary>
	    /// 用于排序的默认值
		/// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
