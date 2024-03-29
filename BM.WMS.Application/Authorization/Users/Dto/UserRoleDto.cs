﻿using Abp.Application.Services.Dto;

namespace BM.WMS.Authorization.Users.Dto
{
    public class UserRoleDto 
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDisplayName { get; set; }

        public bool IsAssigned { get; set; }
    }
}