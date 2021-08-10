using AutoMapper;
using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryApplicationService _CategoryApplicationService;
        private IMapper _Mapper;
        public CategoryController(ICategoryApplicationService CategoryApplicationService,IMapper Mapper)
        {
            _CategoryApplicationService = CategoryApplicationService;
            _Mapper = Mapper;
        }

        public IActionResult Index()
        {
            return View(GetList());
        }
        public ActionResult SaveUpdate(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new CategoryModel());
            }
            else
            {
                Guid Id = new Guid(id);
                var categoryDTO = _CategoryApplicationService.GetCategory(Id);

                if (categoryDTO == null)
                {
                    return NotFound();
                }
                else
                {
                    CategoryModel categoryModel = _Mapper.Map<CategoryModel>(categoryDTO);
                    return Json(categoryModel);
                }
            }
        }

        [HttpPost]
        public IActionResult SaveUpdate(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                CategoryDTO categoryDTO = _Mapper.Map<CategoryDTO>(category);
                var result = _CategoryApplicationService.SaveUpDate(categoryDTO);
            }
            return View("Index", GetList());           
        }

        public IActionResult DeleteCategory(Guid Id)
        {
            var result = _CategoryApplicationService.DeleteCategory(Id);
            return View();
        }
        public List<CategoryModel> GetList()
        {
            var categoryDTO = _CategoryApplicationService.GetAll();
            List<CategoryModel> list = _Mapper.Map<List<CategoryModel>>(categoryDTO);

            return list;
        }
    }
}
