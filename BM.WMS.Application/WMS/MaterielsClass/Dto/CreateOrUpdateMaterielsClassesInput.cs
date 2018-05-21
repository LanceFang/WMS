using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.MaterielsClass;

namespace BM.WMS.MaterielsClass.Dtos
{
    /// <summary>
    /// 物料分类新增和编辑时用Dto
    /// </summary>

    public class CreateOrUpdateMaterielsClassesInput
    {
        /// <summary>
        /// 物料分类编辑Dto
        /// </summary>
        public MaterielsClassesEditDto MaterielsClassesEditDto { get; set; }

    }
}
