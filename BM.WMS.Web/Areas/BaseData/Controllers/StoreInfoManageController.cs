using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using System.Threading.Tasks;
using System.Web.Mvc;
using BM.WMS.Web.Controllers;
using BM.WMS.WMS.Warehouses;
using BM.WMS.WMS.Warehouses.Dtos;
using BM.WMS.Authorization;
using BM.WMS.Web.Areas.BaseData.Models.StoreInfoManage;

namespace BM.WMS.Web.Areas.BaseData.Controllers
{
    public class StoreInfoManageController : WMSControllerBase
    {

        private readonly IStoreInfoAppService _storeInfoAppService;

        public StoreInfoManageController(IStoreInfoAppService storeInfoAppService)
        {
            _storeInfoAppService = storeInfoAppService;
        }

        public ActionResult Index()
        {
            var model = new GetStoreInfoInput { FilterText = Request.QueryString["filterText"] };
            return View(model);
        }

        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(AppPermissions.StoreInfo_CreateStoreInfo, AppPermissions.StoreInfo_EditStoreInfo)]
        public async Task<PartialViewResult> CreateOrEditStoreInfoModal(System.Guid? id)
        {
            var input = new NullableIdDto<System.Guid> { Id = id };

            var output = await _storeInfoAppService.GetStoreInfoForEditAsync(input);

            var viewModel = new CreateOrEditStoreInfoModalViewModel(output);

            return PartialView("_CreateOrEditStoreInfoModal", viewModel);
        }


    }
}