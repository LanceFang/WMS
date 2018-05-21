using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;

namespace BM.WMS.Authorization.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class FlatPermissionDto
    {
        public string ParentName { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsGrantedByDefault { get; set; }
    }
}