using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BM.WMS.Web.Areas.SystemInfo.Models.Common.Modals;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    public class CommonController : WMSControllerBase
    {
        // GET: SystemInfo/Common
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }

        public PartialViewResult SelectUser(SelectUserModalViewModle model)
        {
            return PartialView("Modals/_SelectUser", model);
        }
    }
}