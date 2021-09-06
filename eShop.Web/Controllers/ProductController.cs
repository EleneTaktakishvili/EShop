using AutoMapper;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.Utility;
using eShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductApplicationService _ProductApplicationService;
       
        public ProductController(IProductApplicationService ProductApplicationService)
        {
            _ProductApplicationService = ProductApplicationService; 
        }
        public IActionResult Index(int Page = 1, int PageSize = 8)
        {
            var result = new PagedResults<ProductModel>();
            var productDTO = _ProductApplicationService.GetAll(Page, PageSize);

            var list = new List<ProductModel>();
            foreach (var item in productDTO.Items)
            {
                list.Add(new ProductModel
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    ImagePath = item.ImagePath
                });
            }

            result.Items = list;
            result.TotalCount = productDTO.TotalCount;
            result.CurrentPage = productDTO.CurrentPage;
            result.PageSize = productDTO.PageSize;
         
            return View(result);
        }

        public IActionResult ProductDetails(Guid ProductId)
        {
            List<Guid> CategoryIds = new List<Guid>();
            var categories = GetProductDetails(ProductId).Categories;
            foreach (var item in categories)
            {
                CategoryIds.Add(item.Id);
            }

            ProductDetailsWithRelatedProducts productDetailsWithRelated = new ProductDetailsWithRelatedProducts();
            productDetailsWithRelated.ProductDetails = GetProductDetails(ProductId);  
            productDetailsWithRelated.RelatedProducts = GetRelatedProducts(CategoryIds);

            return View(productDetailsWithRelated);
        }       

        private ProductDetailsModel GetProductDetails(Guid ProductId)
        {
            ProductDetailsModel productDetails = new ProductDetailsModel();
            var categories = new List<CategoryModel>();
            var images = new List<ImageModel>();

            var productDetailsDTO = _ProductApplicationService.GetDetails(ProductId);

            productDetails.ProductId = productDetailsDTO.ProductId;
            productDetails.Name = productDetailsDTO.Name;
            productDetails.Description = productDetailsDTO.Description;
            productDetails.Price = productDetailsDTO.Price;

            foreach (var item in productDetailsDTO.Categories)
            {
                categories.Add(new CategoryModel { Id = item.Id });
            }

            foreach (var item in productDetailsDTO.Images)
            {
                images.Add(new ImageModel 
                { 
                    ImagePath = item.ImagePath, 
                    IsMain = item.IsMain 
                });
            }
            productDetails.Categories = categories;
            productDetails.Images = images;

            return productDetails;
        }
        private ICollection<ProductModel> GetRelatedProducts(List<Guid> CategoryIds)
        {
            ICollection<ProductModel> productModel = new List<ProductModel>();
            var productDTO = _ProductApplicationService.GetRelatedProducts(CategoryIds);

            foreach (var item in productDTO)
            {
                productModel.Add(new ProductModel
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    ImagePath = item.ImagePath

                });
            }
            return productModel;
        }

    }
}
