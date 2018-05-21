namespace BM.WMS.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="AppAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class AppPermissions
    {
        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)
        public const string Pages = "Pages";
        public const string Pages_Administration = "Pages.Administration";

        #region 通用管理 COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";
        public const string Pages_Administration_Users_Impersonation = "Pages.Administration.Users.Impersonation";

        public const string Pages_Administration_Languages = "Pages.Administration.Languages";
        public const string Pages_Administration_Languages_Create = "Pages.Administration.Languages.Create";
        public const string Pages_Administration_Languages_Edit = "Pages.Administration.Languages.Edit";
        public const string Pages_Administration_Languages_Delete = "Pages.Administration.Languages.Delete";
        public const string Pages_Administration_Languages_ChangeTexts = "Pages.Administration.Languages.ChangeTexts";

        public const string Pages_Administration_AuditLogs = "Pages.Administration.AuditLogs";

        public const string Pages_Administration_OrganizationUnits = "Pages.Administration.OrganizationUnits";
        public const string Pages_Administration_OrganizationUnits_ManageOrganizationTree = "Pages.Administration.OrganizationUnits.ManageOrganizationTree";
        public const string Pages_Administration_OrganizationUnits_ManageMembers = "Pages.Administration.OrganizationUnits.ManageMembers";

        #region TENANT-SPECIFIC PERMISSIONS
        public const string Pages_Tenant_Dashboard = "Pages.Tenant.Dashboard";

        public const string Pages_Administration_Tenant_Settings = "Pages.Administration.Tenant.Settings";
        #endregion

        #region HOST-SPECIFIC PERMISSIONS

        public const string Pages_Editions = "Pages.Editions";
        public const string Pages_Editions_Create = "Pages.Editions.Create";
        public const string Pages_Editions_Edit = "Pages.Editions.Edit";
        public const string Pages_Editions_Delete = "Pages.Editions.Delete";

        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Tenants_Create = "Pages.Tenants.Create";
        public const string Pages_Tenants_Edit = "Pages.Tenants.Edit";
        public const string Pages_Tenants_ChangeFeatures = "Pages.Tenants.ChangeFeatures";
        public const string Pages_Tenants_Delete = "Pages.Tenants.Delete";
        public const string Pages_Tenants_Impersonation = "Pages.Tenants.Impersonation";

        public const string Pages_Administration_Host_Maintenance = "Pages.Administration.Host.Maintenance";

        public const string Pages_Administration_Host_Settings = "Pages.Administration.Host.Settings";

        #endregion

        #endregion

        #region 产品信息管理

        public const string Page_ProductManage = "Page.ProductManage";
        public const string Page_ProductManage_Procucts = "Page.ProductManage.Procucts";
        public const string Page_ProductManage_Procucts_Create = "Page.ProductManage.Procucts.Create";
        public const string Page_ProductManage_Procucts_Edit = "Page.ProductManage.Procucts.Edit";
        public const string Page_ProductManage_Procucts_Delete = "Page.ProductManage.Procucts.Delete";

        #endregion

        #region 基础数据管理

        public const string Page_BaseDataManage = "Page.BaseDataManage";
        //物料分类管理权限
        public const string MaterielsClasses = "Pages.MaterielsClasses";
        //物料分类创建权限
        public const string MaterielsClasses_CreateMaterielsClasses = "Pages.MaterielsClasses.CreateMaterielsClasses";
        //物料分类修改权限
        public const string MaterielsClasses_EditMaterielsClasses = "Pages.MaterielsClasses.EditMaterielsClasses";
        //物料分类删除权限
        public const string MaterielsClasses_DeleteMaterielsClasses = "Pages.MaterielsClasses.DeleteMaterielsClasses";

        #region 手写的
        //public const string Page_MaterielsManage_Classes = "Page.MaterielsManage.Classes";
        //public const string Page_MaterielsManage_Classes_Create = "Page.MaterielsManage.Classes.Create";
        //public const string Page_MaterielsManage_Classes_Edit = "Page.MaterielsManage.Classes.Edit";
        //public const string Page_MaterielsManage_Classes_Delete = "Page.MaterielsManage.Classes.Delete";
        #endregion

        // 物料表管理权限
        public const string Materiels = "Pages.Materiels";

        // 物料表创建权限
        public const string Materiels_CreateMateriels = "Pages.Materiels.CreateMateriels";

        // 物料表修改权限
        public const string Materiels_EditMateriels = "Pages.Materiels.EditMateriels";

        // 物料表删除权限
        public const string Materiels_DeleteMateriels = "Pages.Materiels.DeleteMateriels";


        /// <summary>
        /// 库房信息管理权限
        /// </summary>
        public const string StoreInfo = "Pages.StoreInfo";

        /// <summary>
        /// 库房信息创建权限
        /// </summary>
        public const string StoreInfo_CreateStoreInfo = "Pages.StoreInfo.CreateStoreInfo";
        /// <summary>
        /// 库房信息修改权限
        /// </summary>
        public const string StoreInfo_EditStoreInfo = "Pages.StoreInfo.EditStoreInfo";
        /// <summary>
        /// 库房信息删除权限
        /// </summary>
        public const string StoreInfo_DeleteStoreInfo = "Pages.StoreInfo.DeleteStoreInfo";


        /// <summary>
        /// 客户资料管理管理权限
        /// </summary>
        public const string Customers = "Pages.Customers";

        /// <summary>
        /// 客户资料管理创建权限
        /// </summary>
        public const string Customers_CreateCustomers = "Pages.Customers.CreateCustomers";
        /// <summary>
        /// 客户资料管理修改权限
        /// </summary>
        public const string Customers_EditCustomers = "Pages.Customers.EditCustomers";
        /// <summary>
        /// 客户资料管理删除权限
        /// </summary>
        public const string Customers_DeleteCustomers = "Pages.Customers.DeleteCustomers";


        #endregion

    }
}