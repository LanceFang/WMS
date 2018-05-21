using Abp.Application.Navigation;

namespace BM.WMS.Web.Models.Layout
{
    public class SidebarViewModel
    {
        public UserMenu Menu { get; set; }

        public string CurrentPageName { get; set; }
    }
}