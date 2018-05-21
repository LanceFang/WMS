using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Auditing;
using BM.WMS.Authorization;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : WMSControllerBase
    {
        private readonly IAuditLogAppService _iauditLogAppService;

        public AuditLogsController(IAuditLogAppService iauditLogAppService)
        {
            _iauditLogAppService = iauditLogAppService;
        }
        // GET: SystemInfo/AuditLogs
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Detail(int Id)
        {
            var model = await _iauditLogAppService.GetAuditLogAndUserById(Id);
            return PartialView(model);
        }
    }
}