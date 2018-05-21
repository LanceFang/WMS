using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using BM.WMS.MaterielsClass;

namespace BM.WMS.MaterielsClass.Dtos
{
    /// <summary>
    /// 用于添加或编辑 物料分类时使用的DTO
    /// </summary>

    public class GetMaterielsClassesForEditOutput
    {
        /// <summary>
        /// MaterielsClasses编辑状态的DTO
        /// </summary>
        public MaterielsClassesEditDto MaterielsClasses { get; set; }
    }
}
