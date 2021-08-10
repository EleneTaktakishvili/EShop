using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace eShop.Admin.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private IRoleApplicationService _RoleApplicationService;
        private IMapper _Mapper;
        public RoleController(IRoleApplicationService RoleApplicationService, IMapper Mapper)
        {
            _RoleApplicationService = RoleApplicationService;
            _Mapper = Mapper;
        }     
        public IActionResult Index()
        {
            return View(GetList());
        }

        public List<RoleModel> GetList()
        {
            var roleDTO = _RoleApplicationService.GetAll();
            List<RoleModel> list = _Mapper.Map<List<RoleModel>>(roleDTO);
            return list;
        }
    }
}
