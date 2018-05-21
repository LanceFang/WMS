using System.Collections.Generic;
using Abp.Application.Services.Dto;
using BM.WMS.Configuration.Tenants.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}