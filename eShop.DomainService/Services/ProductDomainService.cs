using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
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
        public ICollection<ProductEntity> GetAll()
        {
            return _ProductRepository.GetAll();
        }
    }
}
