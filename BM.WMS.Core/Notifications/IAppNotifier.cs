using System.Threading.Tasks;
using Abp.Notifications;
using BM.WMS.Authorization.Users;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(long userId, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
