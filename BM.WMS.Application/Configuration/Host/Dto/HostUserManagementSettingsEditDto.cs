using Abp.Runtime.Validation;

namespace BM.WMS.Configuration.Host.Dto
{
    public class HostUserManagementSettingsEditDto 
    {
        public bool IsEmailConfirmationRequiredForLogin { get; set; }
    }
}