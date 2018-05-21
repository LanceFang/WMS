﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Text;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Web.MultiTenancy
{
    public class SubdomainTenancyNameFinder : ITenancyNameFinder, ITransientDependency
    {
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public SubdomainTenancyNameFinder(IMultiTenancyConfig multiTenancyConfig)
        {
            _multiTenancyConfig = multiTenancyConfig;
        }

        public string GetCurrentTenancyNameOrNull()
        {
            if (!_multiTenancyConfig.IsEnabled)
            {
                return Tenant.DefaultTenantName;
            }

            if (HttpContext.Current == null || HttpContext.Current.Request.Url == null)
            {
                //Can not find current URL
                return null;
            }

            var currentRootAddress = GetCurrentSiteRootAddress().EnsureEndsWith('/');

            string[] values;
            if (!FormattedStringValueExtracter.IsMatch(currentRootAddress, WebUrlService.WebSiteRootAddress, out values, true))
            {
                return null;
            }

            if (values.Length <= 0)
            {
                return null;
            }

            if (string.Equals(values[0], "www", StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return values[0];
        }

        private static string GetCurrentSiteRootAddress()
        {
            var url = HttpContext.Current.Request.Url;
            return url.Scheme + System.Uri.SchemeDelimiter + url.Host + (url.IsDefaultPort ? "" : ":" + url.Port)
                + HttpContext.Current.Request.ApplicationPath;
        }
    }
}