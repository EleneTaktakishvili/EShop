using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult OrdeDetails(Guid id)
        {
            var orderDetailsDTO = _OrderApplicationService.GetDetails(id);
           List<OrdeDetailsModel> list= _Mapper.Map<List<OrdeDetailsModel>>(orderDetailsDTO);

           return Json(list);
        }
        public List<OrderModel> GetList()
        {
            var orderDTO = _OrderApplicationService.GetAll();
            List<OrderModel> list = _Mapper.Map<List<OrderModel>>(orderDTO);
            return list;
        }
    }
}
