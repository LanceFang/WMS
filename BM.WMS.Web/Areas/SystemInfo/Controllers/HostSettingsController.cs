using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BM.WMS.Web.Controllers;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;
using BM.WMS.Authorization.Users;
using BM.WMS.Configuration.Host;
using BM.WMS.Editions;
using BM.WMS.Timing;
using System.Threading.Tasks;
using BM.WMS.Timing.Dto;
using Abp.Configuration;
using Abp.Timing;
using Abp.Runtime.Session;
using BM.WMS.Web.Areas.SystemInfo.Models.HostSettings;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Settings)]
    public class HostSettingsController : WMSControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IHostSettingsAppService _hostSettingsAppService;
        private readonly IEditionAppService _editionAppService;
        private readonly ITimingAppService _timingAppService;

        public HostSettingsController(
          IHostSettingsAppService hostSettingsAppService,
          UserManager userManager,
          IEditionAppService editionAppService,
          ITimingAppService timingAppService)
        {
            _hostSettingsAppService = hostSettingsAppService;
            _userManager = userManager;
            _editionAppService = editionAppService;
            _timingAppService = timingAppService;
        }
        public async Task<ActionResult> Index()
        {
            var hostSettings = await _hostSettingsAppService.GetAllSettings();
            var editionItems = await _editionAppService.GetEditionComboboxItems(hostSettings.TenantManagement.DefaultEditionId);
            var timezoneItems = await _timingAppService.GetTimezoneComboboxItems(new GetTimezoneComboboxItemsInput
            {
                DefaultTimezoneScope = SettingScopes.Application,
                SelectedTimezoneId = await SettingManager.GetSettingValueForApplicationAsync(TimingSettingNames.TimeZone)
            });

            ViewBag.CurrentUserEmail = await _userManager.GetEmailAsync(AbpSession.GetUserId());

            var model = new HostSettingsViewModel
            {
                Settings = hostSettings,
                EditionItems = editionItems,
                TimezoneItems = timezoneItems
            };

            return View(model);
        }
    }

    
}