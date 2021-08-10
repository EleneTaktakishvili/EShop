using eShop.DataBaseRepository.Db;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ICollection<ProductEntity> GetAll()
        {
            var productDb = new List<ProductEntity>();
            using (eShopDbContext context = new eShopDbContext())
            {
                productDb = (from item in context.ProductsInCategory
                                 select new ProductEntity
                                 {
                                     Id = item.Product.Id,
                                     Name = item.Product.Name,
                                     Description = item.Product.Description,
                                     Price = item.Product.Price,
                                     Quantity = item.Product.Quantity,
                                     ImagePath = item.Product.ProductImages.Where(i => i.IsMain).Select(i => i.ImagePath).SingleOrDefault(),
                                     CategoryId = item.Category.Id,
                                     CategoryName = item.Category.Name
                                 }
                                 ).ToList();

            }
            return productDb;
        }
    }
}
