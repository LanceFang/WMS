using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.MaterielsClass.Dtos;

namespace BM.WMS.Web.Areas.BaseData.Models.MaterielsClassesManage
{
    /// <summary>
    /// 新建或编辑物料分类时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetMaterielsClassesForEditOutput))]
    public class CreateOrEditMaterielsClassesModalViewModel : GetMaterielsClassesForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditMaterielsClassesModalViewModel(GetMaterielsClassesForEditOutput output)
        {
            output.MapTo(this);
        }

        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return MaterielsClasses.Id.HasValue; } }

        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
