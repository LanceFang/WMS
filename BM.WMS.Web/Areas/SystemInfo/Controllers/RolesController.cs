using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Web.Mvc.Authorization;
using BM.WMS.Authorization;
using BM.WMS.Authorization.Roles;
using BM.WMS.Authorization.Roles.Dto;
using BM.WMS.Web.Areas.SystemInfo.Models.Roles;
using BM.WMS.Web.Controllers;

namespace BM.WMS.Web.Areas.SystemInfo.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles)]
    public class RolesController : WMSControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        // GET: SystemInfo/Roles
        public ActionResult Index()
        {
            return View();
        }

        //[AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles_Create, AppPermissions.Pages_Administration_Roles_Edit)]
        //public PartialViewResult CreateOrEditModal(int? id)
        //{
        //    //var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
        //    //var viewModel = new CreateOrEditRoleModalViewModel(output);
        //    ViewBag.RoleId = id;
        //    return PartialView("_CreateOrEditModal");
        //}
        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles_Create, AppPermissions.Pages_Administration_Roles_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            var viewModel = new CreateOrEditRoleModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<JsonResult> GetFormData(int? id)
        {
            //调用递归将权限数据装载到Json
            var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            var nodes = GetTreeNodes(output, null);
            var model = new CreateOrEditRoles() { listTree = nodes, Role = output.Role };
            return Json(model);
        }

        public List<TreeNodes> GetTreeNodes(GetRoleForEditOutput output, string parentName)
        {
            List<TreeNodes> nodes = new List<TreeNodes>();
            var permissions = output.Permissions.Where(item => item.ParentName == parentName || (item.ParentName.IsNullOrEmpty() && parentName.IsNullOrEmpty())).ToList();

            if (!permissions.Any())
            {
                return nodes;
            }
            for (int i = 0; i < permissions.Count(); i++)
            {
                TreeNodes node = new TreeNodes();
                node.id = i;
                node.text = permissions[i].DisplayName;
                node.attributes = permissions[i].Name;
                node.@checked = output.GrantedPermissionNames.Contains(permissions[i].Name);
                node.children = GetTreeNodes(output, permissions[i].Name);
                nodes.Add(node);
            }
            return nodes;
        }

    }
}