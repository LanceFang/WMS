using Abp.Application.Services;
using BM.WMS.Dto;
using BM.WMS.Logging.Dto;

namespace BM.WMS.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
