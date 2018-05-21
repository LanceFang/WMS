using System.Threading.Tasks;
using Abp.Configuration;

namespace BM.WMS.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
