using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Auditing.Dto;
using BM.WMS.Dto;

namespace BM.WMS.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultOutput<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);

        Task<AuditLogAndUser> GetAuditLogAndUserById(int Id);
    }
}