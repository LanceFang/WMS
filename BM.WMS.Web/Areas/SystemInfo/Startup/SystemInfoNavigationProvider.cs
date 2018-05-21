using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Navigation;
using Abp.Localization;
using BM.WMS.Authorization;
using BM.WMS.Web.App_Start.Navigation;

namespace BM.WMS.Web.Areas.SystemInfo.Startup
{
    public class SystemInfoNavigationProvider : NavigationProvider
    {
        public const string MenuName = "BM_WMS";
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            #region 管理后台

            menu.AddItem(new MenuItemDefinition(
                    PageNames.App.Common.Administration,
                    L("Administration"),
                    icon: "fa fa-asterisk"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Tenants,
                        L("Tenants"),
                        url: "SystemInfo/Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: AppPermissions.Pages_Tenants
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Editions,
                        L("Editions"),
                        url: "SystemInfo/Editions",
                        icon: "fa fa-university",
                        requiredPermissionName: AppPermissions.Pages_Editions
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Tenant.Dashboard,
                        L("Dashboard"),
                        url: "SystemInfo/Dashboard",
                        icon: "fa fa-dashboard",
                        requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("OrganizationUnits"),
                        url: "SystemInfo/OrganizationUnits",
                        icon: "fa fa-gears",
                        requiredPermissionName: AppPermissions.Pages_Administration_OrganizationUnits
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Roles,
                        L("Roles"),
                        url: "SystemInfo/Roles",
                        icon: "fa fa-group",
                        requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Users,
                        L("Users"),
                        url: "SystemInfo/Users",
                        icon: "fa fa-user",
                        requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Languages,
                        L("Languages"),
                        url: "SystemInfo/Languages",
                        icon: "fa fa-language",
                        requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.AuditLogs,
                        L("AuditLogs"),
                        url: "SystemInfo/AuditLogs",
                        icon: "fa fa-database",
                        requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Maintenance,
                        L("Maintenance"),
                        url: "SystemInfo/Maintenance",
                        icon: "fa fa-bar-chart",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Maintenance
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Settings,
                        L("Settings"),
                        url: "SystemInfo/HostSettings",
                        icon: "fa fa-wrench",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Tenant.Settings,
                        L("Settings"),
                        url: "SystemInfo/Settings",
                        icon: "fa fa-wrench",
                        requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    ));

            #endregion

            #region 产品管理

            menu.AddItem(new MenuItemDefinition(
                    PageNames.App.Common.ProductManage,
                    L("Manage"),
                    icon: "fa fa-wrench",
                    requiredPermissionName: AppPermissions.Page_ProductManage
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Procuts,
                        L("Prouct"),
                        url: "ManageProduct/Products",
                        icon: "fa fa-wrench",
                        requiredPermissionName: AppPermissions.Page_ProductManage_Procucts
                        )
                   ));

            #endregion

            #region 基础数据管理

            menu.AddItem(new MenuItemDefinition(
                    PageNames.App.Common.BaseDataManage,
                    L("BaseDataManage"),
                    icon: "fa fa-database",
                    requiredPermissionName: AppPermissions.Page_BaseDataManage
                    ).AddItem(
                        new MenuItemDefinition(
                        PageNames.App.Common.MaterielsClasses,
                        L("MaterielsClasses"),
                        url: "BaseData/MaterielsClassesManage",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.MaterielsClasses)
                    ).AddItem(
                        new MenuItemDefinition(
                        PageNames.App.Common.Materiels,
                        L("Materiels"),
                        url: "BaseData/MaterielsManage",
                        icon: "fa fa-cubes",
                        requiredPermissionName: AppPermissions.Materiels)
                    ).AddItem(
                        new MenuItemDefinition(
                        PageNames.App.Common.StoreInfo,
                        L("StoreInfo"),
                        url: "BaseData/StoreInfoManage",
                        icon: "fa fa-codepen",
                        requiredPermissionName: AppPermissions.StoreInfo)
                    ).AddItem(
                        new MenuItemDefinition(
                        PageNames.App.Common.CustomerInfo,
                        L("Customers"),
                        url: "BaseData/CustomerInfoManage",
                        icon: "fa fa-book",
                        requiredPermissionName: AppPermissions.Customers)
                        )
                    );
            #endregion

        }


        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WMSConsts.LocalizationSourceName);
        }
    }
}