using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace eShop.Admin.Controllers
{  
    public class UserController : Controller
    {
        private IUserApplicationService _UserApplicationService;
        private IMapper _Mapper;
        public UserController(IUserApplicationService UserApplicationService, IMapper Mapper)
        {
            _UserApplicationService = UserApplicationService;
            _Mapper = Mapper;
        }
        public IActionResult Index()
        {
            return View(GetList());
        }

        public List<UserModel> GetList()
        {
            var userDTO = _UserApplicationService.GetAll();
            List<UserModel> list = _Mapper.Map<List<UserModel>>(userDTO);

            return list;

        }
    }
}
