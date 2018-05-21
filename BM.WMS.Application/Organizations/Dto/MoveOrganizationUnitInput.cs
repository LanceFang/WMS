using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace BM.WMS.Organizations.Dto
{
    public class MoveOrganizationUnitInput 
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public long? NewParentId { get; set; }
    }
}