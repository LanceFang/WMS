using System.Collections.Generic;
using Abp.Application.Services.Dto;
using BM.WMS.Editions.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}