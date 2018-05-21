using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.WMS.Dto;

namespace BM.WMS.Authorization.Roles.Dto
{
    public class GetRolesInput 
    {
        public string Permission { get; set; }

        public string RoleName { get; set; }
    }
}
