using System.Web.Mvc;

namespace BM.WMS.Web.Areas.SystemInfo
{
    public class SystemInfoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SystemInfo_default",
                "SystemInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}