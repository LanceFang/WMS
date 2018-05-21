using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Services.Dto;
using BM.WMS.Configuration.Host.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public List<ComboboxItemDto> EditionItems { get; set; }
        public HostSettingsEditDto Settings { get; set; }
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}