using Abp;

namespace BM.WMS
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="WMSDomainServiceBase"/>.
    /// For application services inherit AbpZeroTemplateAppServiceBase.
    /// </summary>
    public abstract class WMSServiceBase : AbpServiceBase
    {
        protected WMSServiceBase()
        {
            LocalizationSourceName = WMSConsts.LocalizationSourceName;
        }
    }
}