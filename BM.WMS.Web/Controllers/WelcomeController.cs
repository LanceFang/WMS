using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : WMSControllerBase
    {
        // GET: SystemInfo/Welcome
        public ActionResult Index()
        {
            return View();
        }
    }
}