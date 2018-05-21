using System.Collections.Generic;
using BM.WMS.Auditing.Dto;
using BM.WMS.Dto;

namespace BM.WMS.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
