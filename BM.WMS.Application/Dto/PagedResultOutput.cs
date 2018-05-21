using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace BM.WMS.Dto
{
    public class PagedResultOutput<T>
    {
        public PagedResultOutput(int totals, List<T> rows)
        {
            this.total = totals;
            this.rows = rows;
        }
        public List<T> rows { get; set; }
        public int total { get; set; }
    }
}
