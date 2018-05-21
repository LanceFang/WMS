using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BM.WMS.Web.Utils
{
    public static class ExtendMvcHtml
    {
        public static MvcHtmlString SwitchButtonByEdit(this HtmlHelper helper, string name, bool check)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<input class=\"easyui-switchbutton\" style=\"width:43px;\" value=\"true\" ontext=\"\" id=\"{0}\" name=\"{1}\" offtext=\"\" {2}>", name, name, (!check ? "" : "checked"));

            return new MvcHtmlString(sb.ToString());

        }
        public static MvcHtmlString SwitchButtonByEdit(this HtmlHelper helper, string name, bool check, string ontext, string offtext, string width)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<input class=\"easyui-switchbutton\" value=\"true\"  id=\"{0}\" name=\"{1}\" {2} offtext=\"{3}\" ontext=\"{4}\"  style=\"width:{5}px;\">", name, name, (!check ? "" : "checked"), ontext, offtext, width);

            return new MvcHtmlString(sb.ToString());

        }

        public static MvcHtmlString ToolButtonModel(this HtmlHelper helper, string id, string icon, string text, string keycode, bool hr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<a class=\"searchbtn\" id=\"{0}\" style=\"float: left;\" class=\"l-btn l-btn-plain\">", id);
            sb.AppendFormat("<span class=\"l-btn-left\"><span class=\"l-btn-text {0}\" style=\"font-size:14px\">", icon);
            sb.AppendFormat("</span><span style=\"font-size:12px\">{0}</span></span></a>", text);
            if (hr)
            {
                sb.Append("<div class=\"datagrid-btn-separator\"></div>");
            }
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// 普通按钮
        /// </summary>
        /// <param name="helper">htmlhelper</param>
        /// <param name="id">控件Id</param>
        /// <param name="icon">控件icon图标class</param>
        /// <param name="text">控件的名称</param>
        /// <param name="hr">分割线</param>
        /// <returns>html</returns>
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text, bool hr)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<a id=\"{0}\" style=\"float: left;\" class=\"l-btn l-btn-plain\">", id);
            sb.AppendFormat("<span class=\"l-btn-left\"><span class=\"l-btn-text {0}\" style=\"font-size:14px\">", icon);
            sb.AppendFormat("</span><span style=\"font-size:12px\">{0}</span></span></a>", text);
            if (hr)
            {
                sb.Append("<div class=\"datagrid-btn-separator\"></div>");
            }
            return new MvcHtmlString(sb.ToString());

        }
        /// <summary>
        /// 普通按钮
        /// </summary>
        /// <param name="helper">htmlhelper</param>
        /// <param name="id">控件Id</param>
        /// <param name="icon">控件icon图标class</param>
        /// <param name="text">控件的名称</param>
        /// <param name="hr">分割线</param>
        /// <returns>html</returns>
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text, string title, bool hr)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<a id=\"{0}\" style=\"float: left;\" title=\"{1}\" class=\"l-btn l-btn-plain\">", id, title);
            sb.AppendFormat("<span class=\"l-btn-left\"><span class=\"l-btn-text {0}\" style=\"font-size:14px\">", icon);
            sb.AppendFormat("</span><span style=\"font-size:12px\">{0}</span></span></a>", text);
            if (hr)
            {
                sb.Append("<div class=\"datagrid-btn-separator\"></div>");
            }
            return new MvcHtmlString(sb.ToString());

        }
    }
}