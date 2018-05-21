using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BM.WMS.Caching.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}