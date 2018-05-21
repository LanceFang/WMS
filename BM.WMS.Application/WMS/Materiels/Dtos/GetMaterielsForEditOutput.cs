using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using BM.WMS.Materiels;

namespace BM.WMS.MaterielsManage.Dtos
{
    /// <summary>
    /// 用于添加或编辑 物料表时使用的DTO
    /// </summary>

    public class GetMaterielsForEditOutput
    {
        /// <summary>
        /// Materiels编辑状态的DTO
        /// </summary>
        public MaterielsEditDto Materiels { get; set; }


    }
}
