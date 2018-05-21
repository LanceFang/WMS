using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;
using BM.WMS.Caching;
using BM.WMS.Web.Areas.SystemInfo.Models.Maintenance;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Maintenance)]
    public class MaintenanceController : WMSControllerBase
    {
        private readonly ICachingAppService _cachingAppService;

        public MaintenanceController(ICachingAppService cachingAppService)
        {
            _cachingAppService = cachingAppService;
        }

        public ActionResult Index()
        {
            var model = new MaintenanceViewModel
            {
                Caches = _cachingAppService.GetAllCaches().Items
            };

            return View(model);
        }
    }
}
