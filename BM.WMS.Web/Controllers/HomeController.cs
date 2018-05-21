using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;

namespace BM.WMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : WMSControllerBase
    {
        public async Task<ActionResult> Index()
        {
            //如果当前用户是租主用户则跳转到租户管理页否则
            if (AbpSession.MultiTenancySide == Abp.MultiTenancy.MultiTenancySides.Host)
            {
                if (await IsGrantedAsync(AppPermissions.Pages_Tenants))
                {
                    return RedirectToAction("Index", "Layout");
                }
            }
            else
            {
                if (await IsGrantedAsync(AppPermissions.Pages_Tenant_Dashboard))
                {
                    return RedirectToAction("Index", "Layout");
                }
            }
            return RedirectToAction("Index", "Welcome");
        }
    }
}