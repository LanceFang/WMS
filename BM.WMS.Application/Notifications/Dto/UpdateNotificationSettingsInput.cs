﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace BM.WMS.Notifications.Dto
{
    public class UpdateNotificationSettingsInput 
    {
        public bool ReceiveNotifications { get; set; }

        public List<NotificationSubscriptionDto> Notifications { get; set; }
    }
}