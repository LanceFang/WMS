using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.MaterielsClass;

namespace BM.WMS.MaterielsClass.Dtos
{
    /// <summary>
    /// 物料分类编辑用Dto
    /// </summary>
    [AutoMap(typeof(MaterielsClasses))]
    public class MaterielsClassesEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// 物料分类编号
        /// </summary>
        [DisplayName("物料分类编号")]
        [Required]
        public string ClassCode { get; set; }

        /// <summary>
        /// 物料分类名称
        /// </summary>
        [DisplayName("物料分类名称")]
        [Required]
        public string ClassName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Remark { get; set; }

        public bool IsEnable { get; set; }

    }
}
