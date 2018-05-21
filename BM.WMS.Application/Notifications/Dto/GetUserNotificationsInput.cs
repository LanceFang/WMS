using Abp.Notifications;
using BM.WMS.Dto;

namespace BM.WMS.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}