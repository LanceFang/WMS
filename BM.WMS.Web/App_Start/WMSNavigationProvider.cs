using Abp.Application.Navigation;
using Abp.Localization;
using BM.WMS.Authorization;
using BM.WMS.Web.App_Start.Navigation;

namespace BM.WMS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class WMSNavigationProvider : NavigationProvider
    {

        public const string MenuName = "Frontend";
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Frontend Menu"));

            menu.AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Tenants,
                    L("Tenants"),
                    url: "",
                    icon: "",
                    requiredPermissionName: ""
                ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WMSConsts.LocalizationSourceName);
        }
    }
}
