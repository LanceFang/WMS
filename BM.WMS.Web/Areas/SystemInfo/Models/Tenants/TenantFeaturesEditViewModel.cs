using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.AutoMapper;
using BM.WMS.MultiTenancy;
using BM.WMS.MultiTenancy.Dto;
using BM.WMS.Web.Areas.SystemInfo.Models.Common;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Tenants
{
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}