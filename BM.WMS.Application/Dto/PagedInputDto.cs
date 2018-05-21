using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace BM.WMS.Dto
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(1, AppConsts.MaxPageSize)]//1~1000范围值约束
        public int MaxResultCount
        {
            get
            {
                if (rows == 0)//导出数据的时候没有使用EasyUI 的datagrid
                {
                    return AppConsts.DefaultPageSize;
                }
                return rows;
            }
            set { }
        }

        [Range(0, int.MaxValue)]
        public int SkipCount
        {
            get
            {
                if (page < 1)
                {
                    return rows;
                }
                else
                {
                    return (page - 1) * rows;
                }
            }
            set { }
        }

        public PagedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
        public int rows { get; set; }//每页行数
        public int page { get; set; }//当前页是第几页
        public string order { get; set; }//排序方式
        public string sort { get; set; }//排序列
        public int totalRows { get; set; }//总行数
        public int totalPages //总页数
        {
            get
            {
                return (int)System.Math.Ceiling((float)totalRows / (float)rows);
            }
        }
    }
}