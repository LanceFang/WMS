using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using BM.WMS.Authorization.Users;

namespace BM.WMS.Configuration.Host.Dto
{
    public class SendTestEmailInput 
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}