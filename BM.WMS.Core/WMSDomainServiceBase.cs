using Abp.Domain.Services;

namespace BM.WMS
{
    public abstract class WMSDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected WMSDomainServiceBase()
        {
            LocalizationSourceName = WMSConsts.LocalizationSourceName;
        }
    }
}
