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

        [Route("categories")]
        public IActionResult Index()
        {
            return View(GetList());
        }

        [HttpGet]
        public ActionResult SaveUpdate(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Json(new CategoryModel());
            }
            else
            {               
                var categoryDTO = _CategoryApplicationService.GetCategory(id);

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
            var result = false;

            if (ModelState.IsValid)
            {
                CategoryDTO categoryDTO = _Mapper.Map<CategoryDTO>(category);
                result = _CategoryApplicationService.SaveUpDate(categoryDTO);
            }
            if (result)
            {
                return Json(new { success = true, responseText = "წარმატებით დაემატა!" });
            }
            else
            {
                return Json(new { success = false, responseText = "მოხდა შეცდომა!" });
            }
        }

        public IActionResult DeleteCategory(Guid Id)
        {
            var result = _CategoryApplicationService.DeleteCategory(Id);
            if (result)
            {
                return Json(new { success = true, responseText = "წარმატებით წაიშალა!" });
            }
            else
            {
                return Json(new { success = false, responseText = "მოხდა შეცდომა!" });
            }
        }
        public List<CategoryModel> GetList()
        {
            var categoryDTO = _CategoryApplicationService.GetAll();
            List<CategoryModel> list = _Mapper.Map<List<CategoryModel>>(categoryDTO);

            return list;
        }       
    }
}
