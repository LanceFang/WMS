using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Notifications;

namespace BM.WMS.Notifications.Dto
{
    public class NotificationSubscriptionDto 
    {
        [Required]
        [MaxLength(NotificationInfo.MaxNotificationNameLength)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
    }
}