using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.Materiels;

namespace BM.WMS.MaterielsManage.Dtos
{
    /// <summary>
    /// 物料表新增和编辑时用Dto
    /// </summary>

    public class CreateOrUpdateMaterielsInput
    {
        /// <summary>
        /// 物料表编辑Dto
        /// </summary>
        public MaterielsEditDto MaterielsEditDto { get; set; }

    }
}
