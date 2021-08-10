using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainService.ServiceInterfaces;
using System.Collections.Generic;

namespace eShop.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private IProductDomainService _ProductDomainService;

        public ProductApplicationService(IProductDomainService ProductDomainService)
        {
            _ProductDomainService = ProductDomainService;
        }
        public ICollection<ProductDTO> GetAll()
        {
            ICollection<ProductDTO> productDTO = new List<ProductDTO>();
            var list = _ProductDomainService.GetAll();

            foreach (var item in list)
            {
                productDTO.Add(new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ImagePath = item.ImagePath,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    DateCreated = item.DateCreated,
                    DateChanged = item.DateChanged,
                    DateDeleted = item.DateDeleted

                });
            }
            return productDTO;
        }
    }
}
