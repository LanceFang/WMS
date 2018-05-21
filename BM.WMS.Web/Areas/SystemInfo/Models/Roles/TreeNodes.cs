using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BM.WMS.Authorization.Roles.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Roles
{
    public class TreeNodes
    {
        public int id { get; set; }

        public string text { get; set; }

        public string state { get; set; }

        public bool? @checked { get; set; }//checked 为关键字

        public object attributes { get; set; }

        public List<TreeNodes> children { get; set; }

    }

    public class CreateOrEditRoles
    {
        public List<TreeNodes> listTree { get; set; }

        public RoleEditDto Role { get; set; }
    }
}