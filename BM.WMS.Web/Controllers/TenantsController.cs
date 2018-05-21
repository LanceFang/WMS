using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;
using BM.WMS.MultiTenancy;
using BM.WMS.MultiTenancy.Dto;

namespace BM.WMS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : WMSControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants(new GetTenantsInput());
            return View(output);
        }
    }
}