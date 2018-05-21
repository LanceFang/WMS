using Abp.Web.Mvc.Views;

namespace BM.WMS.Web.Views
{
    public abstract class WMSWebViewPageBase : WMSWebViewPageBase<dynamic>
    {

    }

    public abstract class WMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WMSWebViewPageBase()
        {
            //LocalizationSourceName = WMSConsts.LocalizationSourceName;
        }
    }
}