using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BM.WMS.Web.App_Start.Navigation
{
    public static class PageNames
    {
        public static class App
        {
            public static class Common
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string OrganizationUnits = "Administration.OrganizationUnits";
                public const string Languages = "Administration.Languages";

                #region 业务功能

                public const string ProductManage = "ProductManage";
                public const string Procuts = "ProductManage.Procucts";

                //基础数据管理
                public const string BaseDataManage = "BaseDataManage";
                public const string MaterielsClasses = "BaseDataManage.MaterielsClasses";
                public const string Materiels = "BaseDataManage.Materiels";
                public const string StoreInfo = "BaseDataManage.StoreInfo";
                public const string CustomerInfo = "BaseDataManage.CustomerInfo";
                #endregion
            }

            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Maintenance = "Administration.Maintenance";
                public const string Settings = "Administration.Settings.Host";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
            }
        }
    }
}