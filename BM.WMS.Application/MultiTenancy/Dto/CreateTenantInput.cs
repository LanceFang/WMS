using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using BM.WMS.Authorization.Users;

namespace BM.WMS.MultiTenancy.Dto
{
    public class CreateTenantInput 
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(User.MaxPasswordLength)]
        public string AdminPassword { get; set; }

        public bool ShouldChangePasswordOnNextLogin { get; set; }
        
        public bool SendActivationEmail { get; set; }

        public int? EditionId { get; set; }

        public bool IsActive { get; set; }
    }
}