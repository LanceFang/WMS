using Abp.Runtime.Validation;

namespace BM.WMS.Configuration.Host.Dto
{
    public class TenantManagementSettingsEditDto
    {
        public bool AllowSelfRegistration { get; set; }

        public bool IsNewRegisteredTenantActiveByDefault { get; set; }

        public bool UseCaptchaOnRegistration { get; set; }

        public int? DefaultEditionId { get; set; }
    }
}