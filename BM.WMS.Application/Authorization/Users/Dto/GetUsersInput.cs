using Abp.Runtime.Validation;
using BM.WMS.Dto;

namespace BM.WMS.Authorization.Users.Dto
{
    public class GetUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = $"{sort} {order}" ?? "Name,Surname";
            }
        }
    }
}