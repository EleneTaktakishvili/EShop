using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductApplicationService _ProductApplicationService;
        private IMapper _Mapper;
        public ProductController(IProductApplicationService ProductApplicationService, IMapper Mapper)
        {
            _ProductApplicationService = ProductApplicationService;
            _Mapper = Mapper;
        }
        public IActionResult Index()
        {            
            return View(GetList());
        }

        public List<ProductModel> GetList()
        {
            var productDTO = _ProductApplicationService.GetAll();
            List<ProductModel> list = _Mapper.Map<List<ProductModel>>(productDTO);

            return list;
        }
    }
}
