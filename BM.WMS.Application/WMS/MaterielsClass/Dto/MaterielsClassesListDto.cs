using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BM.WMS.MaterielsClass;

namespace BM.WMS.MaterielsClass.Dtos
{
    /// <summary>
    /// 物料分类列表Dto
    /// </summary>
    [AutoMapFrom(typeof(MaterielsClasses))]
    public class MaterielsClassesListDto : EntityDto<Guid>
    {
        public string ClassCode { get; set; }

        public string ClassName { get; set; }

        public string Remark { get; set; }

        public bool IsEnable { get; set; }


        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
