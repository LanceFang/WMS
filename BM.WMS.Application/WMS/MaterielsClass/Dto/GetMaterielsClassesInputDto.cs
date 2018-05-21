using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using BM.WMS.Dto;

namespace BM.WMS.MaterielsClass.Dto
{
    public class GetMaterielsClassesInputDto : PagedAndSortedInputDto
    {
        public string ClassCode { get; set; }

        public string ClassName { get; set; }

    }
}
