using Abp.AutoMapper;
using Abp.Organizations;

namespace BM.WMS.Web.Areas.SystemInfo.Models.OrganizationUnits
{
    [AutoMapFrom(typeof(OrganizationUnit))]
    public class EditOrganizationUnitModalViewModel
    {
        public long? Id { get; set; }

        public string DisplayName { get; set; }
    }
}