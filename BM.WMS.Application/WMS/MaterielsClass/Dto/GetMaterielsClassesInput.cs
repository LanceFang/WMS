﻿using System;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using BM.WMS.MaterielsClass.Dtos;
using BM.WMS.MaterielsClass;
using BM.WMS.Dto;

namespace BM.WMS.MaterielsClass.Dtos
{
    /// <summary>
    /// 物料分类查询Dto
    /// </summary>
    public class GetMaterielsClassesInput : PagedAndSortedInputDto, IShouldNormalize
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
