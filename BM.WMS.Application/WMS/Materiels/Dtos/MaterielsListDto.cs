using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BM.WMS.Materiels;

namespace BM.WMS.MaterielsManage.Dtos
{
    /// <summary>
    /// 物料表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Materiels))]
    public class MaterielsListDto : EntityDto<System.Guid>
    {
        public string ClassName { get; set; }
        /// <summary>
        /// 物料简码
        /// </summary>
        [DisplayName("物料简码")]
        public string ShortCode { get; set; }
        public string MaterialCode { get; set; }
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
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
