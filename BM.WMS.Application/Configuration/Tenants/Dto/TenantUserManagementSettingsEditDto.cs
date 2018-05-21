using Abp.Runtime.Validation;

namespace BM.WMS.Configuration.Tenants.Dto
{
    public class TenantUserManagementSettingsEditDto 
    {
        public bool AllowSelfRegistration { get; set; }
        
        public bool IsNewRegisteredUserActiveByDefault { get; set; }

        public bool IsEmailConfirmationRequiredForLogin { get; set; }
        
        public bool UseCaptchaOnRegistration { get; set; }
    }
}