using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductApplicationService _ProductApplicationService;
        private ICategoryApplicationService _CategoryApplicationService;
        private readonly IWebHostEnvironment _HostingEnvironment;
        private IMapper _Mapper;
        public ProductController(IProductApplicationService ProductApplicationService, ICategoryApplicationService CategoryApplicationService, IMapper Mapper, IWebHostEnvironment HostingEnvironment)
        {
            _ProductApplicationService = ProductApplicationService;
            _CategoryApplicationService = CategoryApplicationService;
            _HostingEnvironment = HostingEnvironment;
            _Mapper = Mapper;
        }
        public IActionResult Index()
        {            
            return View(GetList());
        }


        public ActionResult SaveUpdate(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Json(GetCategoryList());
            }
            return Json(new ProductModel());
        }

        [HttpPost]
        public ActionResult SaveUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (product.Photos != null && product.Photos.Count > 0)
                {

                    foreach (IFormFile photo in product.Photos)
                    {
                        string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "Images");

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
            }
            return Json(product);
        }


        public List<ProductModel> GetList()
        {
            var productDTO = _ProductApplicationService.GetAll(1,10);
            List<ProductModel> list = _Mapper.Map<List<ProductModel>>(productDTO);

            return list;
        }

        public List<CategoryModel> GetCategoryList()
        {
            var categoryDTO = _CategoryApplicationService.GetAll();
            List<CategoryModel> list = _Mapper.Map<List<CategoryModel>>(categoryDTO);

            return list;
        }
    }
}
