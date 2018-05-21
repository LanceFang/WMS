using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : WMSControllerBase
    {
        // GET: SystemInfo/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}