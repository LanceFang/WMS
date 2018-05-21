using System.Collections.Generic;
using Abp.Application.Services.Dto;
using BM.WMS.Editions.Dto;

namespace BM.WMS.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}