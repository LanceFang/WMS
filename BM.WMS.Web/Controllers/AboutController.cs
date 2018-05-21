using System.Web.Mvc;

namespace BM.WMS.Web.Controllers
{
    public class AboutController : WMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}