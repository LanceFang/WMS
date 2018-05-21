using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace BM.WMS.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        //public string Sorting // 这里赋值会被还原掉
        //{
        //    get
        //    {
        //        return sort + " " + order;
        //    }
        //    set
        //    {

        //    }
        //}
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }


    }
}