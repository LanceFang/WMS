using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BM.WMS.Web.Controllers
{
    public class ApplicationController : WMSControllerBase
    {
        // GET: Application
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}