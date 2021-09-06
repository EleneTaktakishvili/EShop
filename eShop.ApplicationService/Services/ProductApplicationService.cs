using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainService.ServiceInterfaces;
using eShop.DomainService.Services;
using eShop.Utility;
using System;
using System.Collections.Generic;

namespace eShop.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private IProductDomainService _ProductDomainService;
        private IUserDomainService _UserDomainService;

        public ProductApplicationService(IProductDomainService ProductDomainService, IUserDomainService UserDomainService)
        {
            _ProductDomainService = ProductDomainService;
            _UserDomainService = UserDomainService;
        }        

        public PagedResults<ProductDTO> GetAll(int PageNo, int PageSize)
        {
            var result = new PagedResults<ProductDTO>();
            var productDTO = new List<ProductDTO>();
          
            var list = _ProductDomainService.GetAll(PageNo, PageSize);

            foreach (var item in list.Items)
            {
                productDTO.Add(new ProductDTO
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    ImagePath = item.ImagePath
                });               
            }

            result.Items = productDTO;           
            result.TotalCount = list.TotalCount;
            result.CurrentPage = PageNo;
            result.PageSize = PageSize;          

            return result;
        }

        public ProductDetailsDTO GetDetails(Guid ProductId)
        {
            ProductDetailsDTO productDetailsDTO = new ProductDetailsDTO();
            var categories = new List<CategoryDTO>();
            var images = new List<ImageDTO>();

            var item = _ProductDomainService.GetDetails(ProductId);

            productDetailsDTO.ProductId = item.ProductId;
            productDetailsDTO.Name = item.Name;
            productDetailsDTO.Description = item.Description;
            productDetailsDTO.Price = item.Price;

            foreach (var category in item.Categories)
            {
                categories.Add(new CategoryDTO()
                {
                    Id = category.Id
                });
            }
            foreach (var image in item.Images)
            {
                images.Add(new ImageDTO()
                {
                    Id = image.Id,
                    ImagePath = image.ImagePath,
                    IsMain = image.IsMain
                });
            }
            productDetailsDTO.Categories = categories;
            productDetailsDTO.Images = images;

            return productDetailsDTO;
        }

        public ICollection<ProductDTO> GetRelatedProducts(List<Guid> CategoryIds)
        {
            ICollection<ProductDTO> productDTO = new List<ProductDTO>();
            var list = _ProductDomainService.GetRelatedProducts(CategoryIds);

            foreach (var item in list)
            {
                productDTO.Add(new ProductDTO
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    ImagePath = item.ImagePath

                });
            }
            return productDTO;
        }

       
        public ProductsInCarWithTotalDTO GetCartDetails(Guid UserId)
        {
            ProductsInCarWithTotalDTO producInCartDTO = new ProductsInCarWithTotalDTO();

            List<ProductsInCartDTO> productsInCart = new List<ProductsInCartDTO>();
            List<UserAddressDTO> userAddress = new List<UserAddressDTO>();

            var cart = _ProductDomainService.GetCartDetails(UserId);
          
            foreach (var item in cart.productsInCart)
            {
                productsInCart.Add(new ProductsInCartDTO
                {
                    OrdertId = item.OrderId,
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            var address =_UserDomainService.GetUserAddress(UserId);
            foreach (var item in address)
            {
                userAddress.Add(new UserAddressDTO
                {
                    ID = item.ID,
                    UserId=item.UserId,
                    City=item.City,
                    Address=item.Address

                });
              }

            producInCartDTO.productsInCart = productsInCart;
            producInCartDTO.TotalPrice = cart.TotalPrice;
            producInCartDTO.userAddress = userAddress;

            return producInCartDTO;
        }
    }
}
