using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using BM.WMS.Web.Bundling;

namespace BM.WMS.Web.Areas.SystemInfo.Startup
{
    public static class SystemBundelConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            AddMpaCssLibs(bundles, false);
            AddMpaCssLibs(bundles, true);

            bundles.Add(
                new ScriptBundle("~/Bundles/SystemInfo/libs/js")
                .Include(
                    ScriptPaths.SignalR,
                    ScriptPaths.Morris,
                    ScriptPaths.Morris_Raphael,
                    ScriptPaths.JQuery_Sparkline,
                    ScriptPaths.SpinJs,
                    ScriptPaths.SpinJs_JQuery,
                    ScriptPaths.SweetAlert,
                    ScriptPaths.Toastr,
                    ScriptPaths.MomentJs,
                    ScriptPaths.Bootstrap_DateRangePicker,
                    ScriptPaths.Bootstrap_Select,
                    ScriptPaths.Underscore,
                    ScriptPaths.Abp,
                    ScriptPaths.Abp_JQuery,
                    ScriptPaths.Abp_Toastr,
                    ScriptPaths.Abp_BlockUi,
                    ScriptPaths.Abp_SpinJs,
                    ScriptPaths.Abp_SweetAlert,
                    ScriptPaths.Abp_jTable,
                    ScriptPaths.MustacheJs
                    )
                );
        }

        private static void AddMpaCssLibs(BundleCollection bundles, bool isRTL)
        {
            bundles.Add(
                new StyleBundle("~/Bundles/SystemInfo/libs/css" + (isRTL ? "RTL" : ""))
                    .Include(StylePaths.easyui_default, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include(StylePaths.easyui_icon, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .ForceOrdered()
                );
        }
    }
}