using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace BM.WMS.Logging.Dto
{
    public class GetLatestWebLogsOutput 
    {
        public List<string> LatesWebLogLines { get; set; }
    }
}
