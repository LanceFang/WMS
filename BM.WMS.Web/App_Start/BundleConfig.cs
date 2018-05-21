using System.Web.Optimization;
using BM.WMS.Web.Bundling;

namespace BM.WMS.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            #region VENDOR RESOURCES _Layout.cshtml
            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                );



            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                        "~/Scripts/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/Scripts/json2.min.js",
                        "~/Scripts/jquery-2.2.0.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",
                        "~/Scripts/Abp/abp.js",
                        "~/Scripts/Abp/abp.jquery.js",
                        "~/Scripts/Abp/abp.toastr.js",
                        "~/Scripts/Abp/abp.blockUI.js",
                        "~/Scripts/Abp/abp.spin.js",
                        "~/Scripts/Abp/abp.sweet-alert.js",
                        "~/Scripts/jquery.signalR-2.2.1.min.js"
                    )
                );

            //APPLICATION RESOURCES
            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/Content/main.css")
                );

            //~/Bundles/js
            bundles.Add(
                new ScriptBundle("~/Bundles/js")
                    .Include("~/Scripts/main.js")
                );
            #endregion

            //EasyUI datagird dialog 
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                       "~/Scripts/common.js"));

            //EasyUI 
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Scripts/home.js"));

            #region EasyUI 主题CSS引用

            bundles.Add(new StyleBundle("~/Content/themes/coolblacklight/css").Include("~/Content/themes/skin-coolblacklight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/coolblack/css").Include("~/Content/themes/skin-coolblack.css"));
            bundles.Add(new StyleBundle("~/Content/themes/redlight/css").Include("~/Content/themes/skin-redlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/red/css").Include("~/Content/themes/skin-red.css"));
            bundles.Add(new StyleBundle("~/Content/themes/yellowlight/css").Include("~/Content/themes/skin-yellowlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/yellow/css").Include("~/Content/themes/skin-yellow.css"));
            bundles.Add(new StyleBundle("~/Content/themes/purplelight/css").Include("~/Content/themes/skin-purplelight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/purple/css").Include("~/Content/themes/skin-purple.css"));
            bundles.Add(new StyleBundle("~/Content/themes/greenlight/css").Include("~/Content/themes/skin-greenlight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/green/css").Include("~/Content/themes/skin-green.css"));
            bundles.Add(new StyleBundle("~/Content/themes/bluelight/css").Include("~/Content/themes/skin-bluelight.css"));
            bundles.Add(new StyleBundle("~/Content/themes/blue/css").Include("~/Content/themes/skin-blue.css"));

            #endregion

            bundles.Add(new ScriptBundle("~/bundles/json2").Include(
                       "~/Scripts/libs/json2/json2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
                      "~/Scripts/libs/jquery/jquery.min.js"));

            //~/Scripts/libs/jquery-validation/js/jquery.validate.min.js
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").Include(
                      "~/Scripts/libs/jquery-validation/js/jquery.validate.min.js"));

            //~/Scripts/libs/jquery-validation/js/jquery-validation-custom.js
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidatecustom").Include(
                     "~/Scripts/libs/jquery-validation/js/jquery-validation-custom.js"));

            //~/Scripts/libs/jquery-validation/js/jquery.validate.unobtrusive.min.js
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidateunobtrusive").Include(
                    "~/Scripts/libs/jquery-validation/js/jquery.validate.unobtrusive.min.js"));

            //~/Scripts/libs/jquery-validation/js/jquery.validate.unobtrusive.plus.js
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidateunobtrusiveplus").Include(
                    "~/Scripts/libs/jquery-validation/js/jquery.validate.unobtrusive.plus.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryeasyui").Include(
                     "~/Scripts/libs/jquery-easyui-1.5.1/jquery.easyui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfrom").Include(
                       "~/Scripts/libs/jquery-ajax-form/jquery.form.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyui/easyuiplus").Include(
                        "~/Scripts/libs/jquery-easyui-1.5.1/jquery.easyui.plus.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyui/datagridfilter").Include(
                       "~/Scripts/libs/jquery-easyui-1.5.1/datagrid-filter.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.unobtrusive.plus.js"));

            //~/Scripts/moment-with-locales.js
            bundles.Add(new ScriptBundle("~/bundles/momentlocales").Include(
                        "~/Scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                       "~/Scripts/libs/sweetalert/sweet-alert.js"));

            //~/Scripts/libs/jquery-easyui-1.5.1/locale/easyui-lang-" + info + ".js
            var info = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            bundles.Add(new ScriptBundle("~/bundles/easyuilang").Include(
                      "~/Scripts/libs/jquery-easyui-1.5.1/locale/easyui-lang-" + info + ".js"));

            //~/Scripts/underscore.min.js
            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                       "~/Scripts/underscore.min.js"));

            //~/Scripts/My97DatePicker/WdatePicker.js
            bundles.Add(new ScriptBundle("~/bundles/wdatepicker").Include(
                       "~/Scripts/My97DatePicker/WdatePicker.js"));

            //~/Scripts/bootstrap.min.js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.min.js"));

            //~/Content/metronic/assets/global/scripts/app.js
            bundles.Add(new ScriptBundle("~/bundles/metronicapp").Include(
                       "~/Content/metronic/assets/global/scripts/app.js"));

            //~/Content/metronic/assets/admin/layout4/scripts/layout.js
            bundles.Add(new ScriptBundle("~/bundles/metroniclayout").Include(
                       "~/Content/metronic/assets/admin/layout4/scripts/layout.js"));

            //~/Content/metronic/assets/layouts/global/scripts/quick-sidebar.js
            bundles.Add(new ScriptBundle("~/bundles/metronicquick").Include(
                       "~/Content/metronic/assets/layouts/global/scripts/quick-sidebar.js"));

            bundles.Add(new StyleBundle("~/Content/easyui").Include(
                "~/Content/themes/base/easyui.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/fontawesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapmin").Include(
                "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/sweetalert").Include(
                "~/Scripts/libs/sweetalert/sweet-alert.css"));

            //~/Scripts/libs/jstree/themes/default/style.css
            bundles.Add(new StyleBundle("~/Content/jstree").Include(
                "~/Scripts/libs/jstree/themes/default/style.css"));

            //~/Content/metronic/assets/global/css/components-md.css
            bundles.Add(new StyleBundle("~/Content/componentsmd").Include(
                "~/Content/metronic/assets/global/css/components-md.css"));

            //~/Content/toastr.css
            bundles.Add(new StyleBundle("~/Content/toastr").Include(
               "~/Content/toastr.css"));

            //~/Content/metronic/assets/global/css/plugins-md.css
            bundles.Add(new StyleBundle("~/Content/pluginsmd").Include(
              "~/Content/metronic/assets/global/css/plugins-md.css"));

            //~/Content/metronic/assets/admin/layout4/css/layout.css
            bundles.Add(new StyleBundle("~/Content/layout4css").Include(
              "~/Content/metronic/assets/admin/layout4/css/layout.css"));

            //~/Content/metronic/assets/admin/layout4/css/themes/light.css
            bundles.Add(new StyleBundle("~/Content/themeslight").Include(
             "~/Content/metronic/assets/admin/layout4/css/themes/light.css"));

            //COMMON BUNDLES USED BOTH IN FRONTEND AND BACKEND

            bundles.Add(
                new StyleBundle("~/Bundles/Common/css")
                    .IncludeDirectory("~/Common/Styles", "*.css", true)
                    .ForceOrdered()
                );

            bundles.Add(
                new ScriptBundle("~/Bundles/Common/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .ForceOrdered()
                );
        }
    }
}