using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using BM.WMS.MaterielsManage;

namespace BM.WMS.MaterielsManage.Dtos
{
    /// <summary>
    /// 物料表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Materiels))]
    public class MaterielsEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public System.Guid? Id { get; set; }

        public Guid MaterialClassId { get; set; }

        public string ClassName { get; set; }

        /// <summary>
        /// 物料简码
        /// </summary>
        [DisplayName("物料简码")]
        public string ShortCode { get; set; }

        [Required]
        [RegularExpression(BM.WMS.WMSConsts.MaterielsCodeRegex)]
        public string MaterialCode { get; set; }

        [Required]
        public string MaterialName { get; set; }

        /// <summary>
        /// 物料全称
        /// </summary>
        [DisplayName("物料全称")]
        public string FullName { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        [DisplayName("助记码")]
        public string HelperCode { get; set; }

        [Required]
        public string Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DisplayName("单位")]
        public string Unit { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Remark { get; set; }

    }
}
