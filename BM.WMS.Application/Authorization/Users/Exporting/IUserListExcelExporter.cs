using System.Collections.Generic;
using BM.WMS.Authorization.Users.Dto;
using BM.WMS.Dto;

namespace BM.WMS.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}