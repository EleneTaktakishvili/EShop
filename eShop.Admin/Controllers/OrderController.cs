using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace eShop.Admin.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderApplicationService _OrderApplicationService;
        private IMapper _Mapper;
        public OrderController(IOrderApplicationService OrderApplicationService, IMapper Mapper)
        {
            _OrderApplicationService = OrderApplicationService;
            _Mapper = Mapper;
        }

        public IActionResult Index()
        {
            return View(GetList());
        }

        public List<OrderModel> GetList()
        {
            var orderDTO = _OrderApplicationService.GetAll();
            List<OrderModel> list = _Mapper.Map<List<OrderModel>>(orderDTO);
            return list;
        }
    }
}
