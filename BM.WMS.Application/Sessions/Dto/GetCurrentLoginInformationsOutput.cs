﻿using Abp.Application.Services.Dto;

namespace BM.WMS.Sessions.Dto
{
    public class GetCurrentLoginInformationsOutput 
    {
        public UserLoginInfoDto User { get; set; }

        public TenantLoginInfoDto Tenant { get; set; }
    }
}