using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;


namespace eShop.DomainService.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private IProductRepository _ProductRepository;

        public ProductDomainService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
      
        public PagedResults<ProductEntity> GetAll(int PageNo, int PageSize)
        {
            return _ProductRepository.GetAll(PageNo, PageSize);
        }

        public ProductDetailsEntity GetDetails(Guid ProductId)
        {
            return _ProductRepository.GetDetails(ProductId);
        }

        public ICollection<ProductEntity> GetRelatedProducts(List<Guid> CategoryIds)
        {
            return _ProductRepository.GetRelatedProducts(CategoryIds);
        }      

        public ProductsInCartWithTotalEntity GetCartDetails(Guid UserId)
        {
            return _ProductRepository.GetCartDetails(UserId);
        }


    }
}
