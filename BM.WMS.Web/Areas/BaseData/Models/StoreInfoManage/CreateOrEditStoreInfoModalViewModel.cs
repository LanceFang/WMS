using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.WMS.Warehouses.Dtos;

namespace BM.WMS.Web.Areas.BaseData.Models.StoreInfoManage
{
    /// <summary>
    /// 新建或编辑库房信息时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetStoreInfoForEditOutput))]
    public class CreateOrEditStoreInfoModalViewModel : GetStoreInfoForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditStoreInfoModalViewModel(GetStoreInfoForEditOutput output)
        {
            output.MapTo(this);
        }

        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return StoreInfo.Id.HasValue; } }



        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
