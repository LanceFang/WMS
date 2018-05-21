using System.Configuration;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Extensions;
using BM.WMS.Configuration;

namespace BM.WMS.Web
{
    public class WebUrlService : IWebUrlService, ITransientDependency
    {
        public const string TenancyNamePlaceHolder = "{TENANCY_NAME}";

        public static string WebSiteRootAddress => ConfigurationManager.AppSettings["WebSiteRootAddress"].EnsureEndsWith('/');

        private readonly ISettingManager _settingManager;

        public WebUrlService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public string GetSiteRootAddress(string tenancyName = null)
        {
            var siteRootFormat = WebSiteRootAddress;//_settingManager.GetSettingValue(AppSettings.General.WebSiteRootAddress).EnsureEndsWith('/');

            if (!siteRootFormat.Contains(TenancyNamePlaceHolder))
            {
                return siteRootFormat;
            }

            if (siteRootFormat.Contains(TenancyNamePlaceHolder + "."))
            {
                siteRootFormat = siteRootFormat.Replace(TenancyNamePlaceHolder + ".", TenancyNamePlaceHolder);
            }

            if (tenancyName.IsNullOrEmpty())
            {
                return siteRootFormat.Replace(TenancyNamePlaceHolder, "");
            }

            return siteRootFormat.Replace(TenancyNamePlaceHolder, tenancyName + ".");
        }
    }
}