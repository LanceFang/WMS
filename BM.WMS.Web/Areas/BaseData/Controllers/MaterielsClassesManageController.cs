using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BM.WMS.Web.Controllers;
using BM.WMS.MaterielsClass;
using BM.WMS.MaterielsClass.Dtos;
using BM.WMS.Web.Areas.BaseData.Models.MaterielsClassesManage;
using BM.WMS.Authorization;

namespace BM.WMS.Web.Areas.BaseData.Controllers
{
    public class MaterielsClassesManageController : WMSControllerBase
    {

        private readonly IMaterielsClassesAppService _materielsClassesAppService;

        public MaterielsClassesManageController(IMaterielsClassesAppService materielsClassesAppService)
        {
            _materielsClassesAppService = materielsClassesAppService;

        }

        public ActionResult Index()
        {
            var model = new GetMaterielsClassesInput { FilterText = Request.QueryString["filterText"] };
            return View(model);
        }

        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(AppPermissions.MaterielsClasses_CreateMaterielsClasses, AppPermissions.MaterielsClasses_EditMaterielsClasses)]
        public async Task<PartialViewResult> CreateOrEditMaterielsClassesModal(Guid? id)
        {
            var input = new NullableIdDto<Guid> { Id = id };

            var output = await _materielsClassesAppService.GetMaterielsClassesForEditAsync(input);

            var viewModel = new CreateOrEditMaterielsClassesModalViewModel(output);


            return PartialView("_CreateOrEditMaterielsClassesModal", viewModel);
        }


    }
}