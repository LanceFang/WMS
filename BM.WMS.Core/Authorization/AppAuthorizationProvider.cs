using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BM.WMS.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            #region 管理

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            //该功能实现的还不太成熟（技术有限吧）
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));

            //TENANT-SPECIFIC PERMISSIONS

            administration.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = administration.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = administration.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            //tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: MultiTenancySides.Host);

            #endregion

            #region 产品

            var MangageProduct = pages.CreateChildPermission(AppPermissions.Page_ProductManage, L("Manage"));

            var producs = MangageProduct.CreateChildPermission(AppPermissions.Page_ProductManage_Procucts, L("Product"));
            producs.CreateChildPermission(AppPermissions.Page_ProductManage_Procucts_Create, L("CreateProducts"));
            producs.CreateChildPermission(AppPermissions.Page_ProductManage_Procucts_Edit, L("EditProducts"));
            producs.CreateChildPermission(AppPermissions.Page_ProductManage_Procucts_Delete, L("DeleteProducts"));

            #endregion

            #region 基础数据管理

            var baseDataManage = pages.CreateChildPermission(AppPermissions.Page_BaseDataManage, L("BaseDataManage"));

            var materielsClasses = baseDataManage.CreateChildPermission(AppPermissions.MaterielsClasses, L("MaterielsClasses"));
            materielsClasses.CreateChildPermission(AppPermissions.MaterielsClasses_CreateMaterielsClasses, L("CreateMaterielsClasses"));
            materielsClasses.CreateChildPermission(AppPermissions.MaterielsClasses_EditMaterielsClasses, L("EditMaterielsClasses"));
            materielsClasses.CreateChildPermission(AppPermissions.MaterielsClasses_DeleteMaterielsClasses, L("DeleteMaterielsClasses"));


            var materiels = baseDataManage.CreateChildPermission(AppPermissions.Materiels, L("Materiels"));
            materiels.CreateChildPermission(AppPermissions.Materiels_CreateMateriels, L("CreateMateriels"));
            materiels.CreateChildPermission(AppPermissions.Materiels_EditMateriels, L("EditMateriels"));
            materiels.CreateChildPermission(AppPermissions.Materiels_DeleteMateriels, L("DeleteMateriels"));

            var storeInfo = baseDataManage.CreateChildPermission(AppPermissions.StoreInfo, L("StoreInfo"));
            storeInfo.CreateChildPermission(AppPermissions.StoreInfo_CreateStoreInfo, L("CreateStoreInfo"));
            storeInfo.CreateChildPermission(AppPermissions.StoreInfo_EditStoreInfo, L("EditStoreInfo"));
            storeInfo.CreateChildPermission(AppPermissions.StoreInfo_DeleteStoreInfo, L("DeleteStoreInfo"));

            var customers = baseDataManage.CreateChildPermission(AppPermissions.Customers, L("Customers"));
            customers.CreateChildPermission(AppPermissions.Customers_CreateCustomers, L("CreateCustomers"));
            customers.CreateChildPermission(AppPermissions.Customers_EditCustomers, L("EditCustomers"));
            customers.CreateChildPermission(AppPermissions.Customers_DeleteCustomers, L("DeleteCustomers"));

            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WMSConsts.LocalizationSourceName);
        }
    }
}
