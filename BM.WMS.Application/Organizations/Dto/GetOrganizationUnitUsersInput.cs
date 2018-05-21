using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using BM.WMS.Dto;

namespace BM.WMS.Organizations.Dto
{
    public class GetOrganizationUnitUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }


        public void Normalize()
        {
            if (!string.IsNullOrEmpty(sort))
            {
                Sorting = $"{sort} {order}";
            }
            //if (string.IsNullOrEmpty(Sorting))
            //{
            //    Sorting = "user.Name, user.Surname";
            //}
            if (sort.Contains("userName"))
            {
                Sorting = Sorting.Replace("userName", "user.userName");
            }
            else if (sort.Contains("addedTime"))
            {
                Sorting = Sorting.Replace("addedTime", "uou.creationTime");
            }
        }
    }
}