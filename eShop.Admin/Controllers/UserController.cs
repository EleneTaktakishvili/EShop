using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace eShop.Admin.Controllers
{  
    public class UserController : Controller
    {
        private IUserApplicationService _UserApplicationService;
        private IRoleApplicationService _RoleApplicationService;
        private IMapper _Mapper;
        public UserController(IUserApplicationService UserApplicationService, IRoleApplicationService RoleApplicationService, IMapper Mapper)
        {
            _UserApplicationService = UserApplicationService;
            _RoleApplicationService = RoleApplicationService;
            _Mapper = Mapper;
        }
        public IActionResult Index()
        {
            return View(GetList());
        }

        public IActionResult SaveUpdate(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return Json(GetRoles());
            }
            return View();
        }

        public List<UserModel> GetList()
        {
            var userDTO = _UserApplicationService.GetAll();
            List<UserModel> list = _Mapper.Map<List<UserModel>>(userDTO);

            return list;

        }

        public List<RoleModel> GetRoles()
        {
            var roleDTO = _RoleApplicationService.GetAll();
            return  _Mapper.Map<List<RoleModel>>(roleDTO);  
        }

    }
}
