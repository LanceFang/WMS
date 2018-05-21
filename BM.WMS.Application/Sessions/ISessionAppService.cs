using System.Threading.Tasks;
using Abp.Application.Services;
using BM.WMS.Sessions.Dto;

namespace BM.WMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
