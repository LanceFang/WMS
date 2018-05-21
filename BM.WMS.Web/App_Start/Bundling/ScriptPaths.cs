using System.IO;
using System.Threading;
using System.Web;
using Abp.Extensions;

namespace BM.WMS.Web.Bundling
{
    public static class ScriptPaths
    {
        public const string Json2 = "~/Scripts/libs/json2/json2.min.js";

        #region JQuery

        public const string JQuery = "~/Scripts/libs/jquery/jquery.min.js";
        public const string JQuery_Migrate = "~/Scripts/libs/jquery/jquery-migrate.min.js";
        public const string JQuery_UI = "~/Scripts/libs/jquery-ui/jquery-ui.min.js";

        public const string JQuery_Slimscroll = "~/Scripts/libs/jquery-slimscroll/jquery.slimscroll.min.js";
        public const string JQuery_BlockUi = "~/Scripts/libs/jquery-blockui/jquery.blockui.min.js";
        public const string JQuery_Cookie = "~/Scripts/libs/jquery-cookie/jquery.cookie.min.js";
        public const string JQuery_Uniform = "~/Scripts/libs/jquery-uniform/jquery.uniform.min.js";
        public const string JQuery_Ajax_Form = "~/Scripts/libs/jquery-ajax-form/jquery.form.js";
        public const string JQuery_Sparkline = "~/Scripts/libs/jquery-sparkline/jquery.sparkline.min.js";
        public const string JQuery_Validation = "~/Scripts/libs/jquery-validation/js/jquery.validate.min.js";
        public const string JQuery_jTable = "~/Scripts/libs/jquery-jtable/jquery.jtable.min.js";
        public const string JQuery_Bootstrap_Switch = "~/Scripts/libs/bootstrap-switch/js/bootstrap-switch.min.js";
        public const string JQuery_Color = "~/Scripts/libs/jcrop/js/jquery.color.js";
        public const string JQuery_Jcrop = "~/Scripts/libs/jcrop/js/jquery.Jcrop.min.js";

        #endregion

        #region Bootstrap

        public const string Bootstrap = "~/Scripts/libs/bootstrap/js/bootstrap.min.js";
        public const string Bootstrap_Hover_Dropdown = "~/Scripts/libs/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js";
        public const string Bootstrap_DateRangePicker = "~/Scripts/libs/bootstrap-daterangepicker/daterangepicker.js";
        public const string Bootstrap_Select = "~/Scripts/libs/bootstrap-select/bootstrap-select.min.js";
        public const string Bootstrap_Switch = "~/Scripts/libs/bootstrap-switch/js/bootstrap-switch.min.js";

        #endregion

        #region Otherjs

        public const string SignalR = "~/Scripts/jquery.signalR-2.2.0.min.js";

        public const string Morris = "~/Scripts/libs/morris/morris.min.js";
        public const string Morris_Raphael = "~/Scripts/libs/morris/raphael-min.js";

        public const string JsTree = "~/Scripts/libs/jstree/jstree.js";
        public const string SpinJs = "~/Scripts/libs/spinjs/spin.js";
        public const string SpinJs_JQuery = "~/Scripts/libs/spinjs/jquery.spin.js";

        public const string SweetAlert = "~/Scripts/libs/sweetalert/sweet-alert.js";
        public const string Toastr = "~/Scripts/toastr.min.js";

        public const string MomentJs = "~/Scripts/moment-with-locales.min.js";
        public const string Underscore = "~/Scripts/underscore.min.js";

        public const string MustacheJs = "~/Scripts/libs/mustachejs/mustache.min.js";

        #endregion

        #region Angular

        public const string Angular = "~/Scripts/angular.min.js";
        public const string Angular_Sanitize = "~/Scripts/angular-sanitize.min.js";
        public const string Angular_Touch = "~/Scripts/angular-touch.min.js";
        public const string Angular_Ui_Router = "~/Scripts/angular-ui-router.min.js";
        public const string Angular_Ui_Utils = "~/Scripts/angular-ui/ui-utils.min.js";
        public const string Angular_Ui_Bootstrap_Tpls = "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js";
        public const string Angular_Ui_Grid = "~/Scripts/libs/angular-ui-grid/ui-grid.min.js";
        public const string Angular_OcLazyLoad = "~/Scripts/libs/angular-ocLazyLoad/ocLazyLoad.min.js";
        public const string Angular_File_Upload = "~/Scripts/libs/angular-file-upload/angular-file-upload.min.js";
        public const string Angular_DateRangePicker = "~/Scripts/libs/angular-daterangepicker/angular-daterangepicker.min.js";
        public const string Angular_Moment = "~/Scripts/libs/angular-moment/angular-moment.min.js";
        public const string Angular_Bootstrap_Switch = "~/Scripts/libs/angular-bootstrap-switch/angular-bootstrap-switch.min.js";

        #endregion

        #region Abp

        public const string Abp = "~/Scripts/Abp/abp.js";
        public const string Abp_JQuery = "~/Scripts/Abp/abp.jquery.js";
        public const string Abp_Moment= "~/Scripts/Abp/abp.moment.js";
        public const string Abp_Toastr = "~/Scripts/Abp/abp.toastr.js";
        public const string Abp_BlockUi = "~/Scripts/Abp/abp.blockUI.js";
        public const string Abp_SpinJs = "~/Scripts/Abp/abp.spin.js";
        public const string Abp_SweetAlert = "~/Scripts/Abp/abp.sweet-alert.js";
        public const string Abp_Angular = "~/Scripts/Abp/abp.ng.js";
        public const string Abp_jTable = "~/Scripts/Abp/abp.jtable.js";

        #endregion

        #region EasyUi

        public const string easyui_min = "~/Scripts/libs/jquery-easyui-1.5.1/jquery.easyui.min.js";
        public const string easyui_easyloader = "~/Scripts/libs/jquery-easyui-1.5.1/src/easyloader.js";
        public const string easyui_accordion = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.accordion.js";
        public const string easyui_calendar = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.calendar.js";
        public const string easyui_combobox = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.combobox.js";
        public const string easyui_datebox = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.datebox.js";
        public const string easyui_draggable = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.draggable.js";
        public const string easyui_droppable = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.droppable.js";
        public const string easyui_form = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.form.js";
        public const string easyui_linkbutton = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.linkbutton.js";
        public const string easyui_menu = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.menu.js";
        public const string easyui_parser = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.parser.js";
        public const string easyui_progressbar = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.progressbar.js";
        public const string easyui_propertygrid = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.propertygrid.js";
        public const string easyui_resizable = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.resizable.js";
        public const string easyui_slider = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.slider.js";
        public const string easyui_tabs = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.tabs.js";
        public const string easyui_window = "~/Scripts/libs/jquery-easyui-1.5.1/src/jquery.window.js";

        #endregion

        public static string Angular_Localization
        {
            get
            {
                return GetLocalizationFileForjAngularOrNull(Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                       ?? GetLocalizationFileForjAngularOrNull(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                       ?? "~/Scripts/i18n/angular-locale_en-us.js";
            }
        }

        private static string GetLocalizationFileForjAngularOrNull(string cultureCode)
        {
            try
            {
                var relativeFilePath = "~/Scripts/i18n/angular-locale_" + cultureCode + ".js";
                var physicalFilePath = HttpContext.Current.Server.MapPath(relativeFilePath);
                if (File.Exists(physicalFilePath))
                {
                    return relativeFilePath;
                }
            }
            catch { }

            return null;
        }


        public static string JQuery_Validation_Localization
        {
            get
            {
                return GetLocalizationFileForjQueryValidationOrNull(Thread.CurrentThread.CurrentUICulture.Name.ToLower().Replace("-", "_"))
                       ?? GetLocalizationFileForjQueryValidationOrNull(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                       ?? "~/Scripts/libs/jquery-validation/js/localization/_messages_empty.js";
            }
        }

        private static string GetLocalizationFileForjQueryValidationOrNull(string cultureCode)
        {
            try
            {
                var relativeFilePath = "~/Scripts/libs/jquery-validation/js/localization/messages_" + cultureCode + ".min.js";
                var physicalFilePath = HttpContext.Current.Server.MapPath(relativeFilePath);
                if (File.Exists(physicalFilePath))
                {
                    return relativeFilePath;
                }
            }
            catch { }

            return null;
        }

        public static string JQuery_JTable_Localization
        {
            get
            {
                return GetLocalizationFileForJTableOrNull(Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                       ?? GetLocalizationFileForJTableOrNull(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                       ?? "~/Scripts/libs/jquery-jtable/localization/_jquery.jtable.empty.js";
            }
        }

        private static string GetLocalizationFileForJTableOrNull(string cultureCode)
        {
            try
            {
                var relativeFilePath = "~/Scripts/libs/jquery-jtable/localization/jquery.jtable." + cultureCode + ".js";
                var physicalFilePath = HttpContext.Current.Server.MapPath(relativeFilePath);
                if (File.Exists(physicalFilePath))
                {
                    return relativeFilePath;
                }
            }
            catch { }

            return null;
        }

        public static string Bootstrap_Select_Localization
        {
            get
            {
                return GetLocalizationFileForBootstrapSelect(Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                       ?? GetLocalizationFileForBootstrapSelect(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                       ?? "~/Scripts/libs/bootstrap-select/i18n/defaults-en_US.js";
            }
        }

        private static string GetLocalizationFileForBootstrapSelect(string cultureCode)
        {
            var localizationFileList = new[]
            {
                "ar_AR",
                "bg_BG",
                "cs_CZ",
                "da_DK",
                "de_DE",
                "en_US",
                "es_CL",
                "eu",
                "fa_IR",
                "fi_FI",
                "fr_FR",
                "hu_HU",
                "id_ID",
                "it_IT",
                "ko_KR",
                "nb_NO",
                "nl_NL",
                "pl_PL",
                "pt_BR",
                "pt_PT",
                "ro_RO",
                "ru_RU",
                "sk_SK",
                "sl_SL",
                "sv_SE",
                "tr_TR",
                "ua_UA",
                "zh_CN",
                "zh_TW"
            };

            try
            {
                cultureCode = cultureCode.Replace("-", "_");

                foreach (var localizationFile in localizationFileList)
                {
                    if (localizationFile.StartsWith(cultureCode))
                    {
                        return "~/Scripts/libs/bootstrap-select/i18n/defaults-" + localizationFile + ".js";
                    }
                }
            }
            catch { }

            return null;
        }
    }
}