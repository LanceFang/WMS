using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.MaterielsManage.Dtos;

namespace BM.WMS.Web.Areas.BaseData.Models.MaterielsManage
{
    /// <summary>
    /// 新建或编辑物料表时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetMaterielsForEditOutput))]
    public class CreateOrEditMaterielsModalViewModel : GetMaterielsForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditMaterielsModalViewModel(GetMaterielsForEditOutput output)
        {
            output.MapTo(this);
        }

        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return Materiels.Id.HasValue; } }

        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
