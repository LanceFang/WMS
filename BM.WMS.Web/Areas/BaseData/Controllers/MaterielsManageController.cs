using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using System.Threading.Tasks;
using System.Web.Mvc;
using BM.WMS.Web.Controllers;
using BM.WMS.MaterielsManage;
using BM.WMS.Authorization;
using BM.WMS.MaterielsManage.Dtos;
using BM.WMS.Web.Areas.BaseData.Models.MaterielsManage;

namespace BM.WMS.Web.Areas.BaseData.Controllers
{
    public class MaterielsManageController : WMSControllerBase
    {

        private readonly IMaterielsAppService _materielsAppService;

        public MaterielsManageController(IMaterielsAppService materielsAppService)
        {
            _materielsAppService = materielsAppService;

        }

        public ActionResult Index()
        {
            var model = new GetMaterielsInput { FilterText = Request.QueryString["filterText"] };
            return View(model);
        }

        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(AppPermissions.Materiels_CreateMateriels, AppPermissions.Materiels_EditMateriels)]
        public async Task<PartialViewResult> CreateOrEditMaterielsModal(System.Guid? id)
        {
            var input = new NullableIdDto<System.Guid> { Id = id };

            var output = await _materielsAppService.GetMaterielsForEditAsync(input);

            var viewModel = new CreateOrEditMaterielsModalViewModel(output);

            return PartialView("_CreateOrEditMaterielsModal", viewModel);
        }

        public PartialViewResult SelectMaterielsClass()
        {
            return PartialView("_SelectMaterielsClass");
        }

    }
}