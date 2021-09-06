using Dapper;
using eShop.DataBaseRepository.Dapper;
using eShop.DataBaseRepository.Db;
using eShop.DataBaseRepository.Db.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }
        public PagedResults<ProductEntity> GetAll(int PageNo, int PageSize)
        {
            using (var connection = _context.CreateConnection())
            {
                var results = new PagedResults<ProductEntity>();

                var productEntity = new List<ProductEntity>();

                string procName = "GetAllProducts";
                var _params = new DynamicParameters();
                _params.Add("@PageNo", PageNo);
                _params.Add("@PageSize", PageSize);
                _params.Add("@TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                results.Items = connection.Query<ProductEntity>(procName, _params,  commandType: CommandType.StoredProcedure);                
                results.TotalCount = _params.Get<int>("TotalCount");  
                
                results.CurrentPage = PageNo;
                results.PageSize = PageSize;
                return results;
            }
          
        }
        public ProductDetailsEntity GetDetails(Guid ProductId)
        {
            ProductDetailsEntity productEntity = new ProductDetailsEntity();           
            var categories = new List<CategoryEntity>();
            var images = new List<ImageEntity>();

            using (var connection = _context.CreateConnection())
            {
                string procName = "GetProductDetails";
                var _params = new DynamicParameters();
                _params.Add("@ProductId", ProductId);

                var productDetails = connection.Query<Products, ProductImages,ProductsInCategory, Products>(procName,
                   (p, i, c) =>
                   {
                       p.ProductImages.Add(i);
                       p.ProductsInCategory.Add(c);
                       return p;
                   }, 
                    param: _params, 
                    splitOn:"ImageId, CategoryId",
                    commandType: CommandType.StoredProcedure);

                foreach (var item in productDetails)
                {
                    productEntity.ProductId = item.ProductId;
                    productEntity.Name = item.Name;
                    productEntity.Description = item.Description;
                    productEntity.Price = item.Price;
                  
                    foreach (var image in item.ProductImages)
                    {
                        images.Add(new ImageEntity()
                        {
                            Id = image.ImageId,
                            ImagePath = image.ImagePath,
                            IsMain = image.IsMain
                        });
                    }
                   
                    foreach (var category in item.ProductsInCategory)
                    {
                        categories.Add(new CategoryEntity()
                        {
                            Id = category.CategoryId
                        });
                    }
                }
            }
            productEntity.Images = images.GroupBy(i => new { i.Id, i.IsMain }).Select(x => x.First()).ToList();
            productEntity.Categories = categories.GroupBy(c => c.Id).Select(x => x.First()).ToList();
            return productEntity;
        }
        public ICollection<ProductEntity> GetRelatedProducts(List<Guid> CategoryIds)
        {          
            using (var connection = _context.CreateConnection())
            {
                ICollection<ProductEntity> productEntity = new List<ProductEntity>();

                var categoryIds = string.Join(",", CategoryIds.ToArray());
                string procName = "GetRelatedProducts";
                var _params = new DynamicParameters();
                _params.Add("@CategoryIds", categoryIds);

                productEntity = connection.Query<ProductEntity>(procName, _params, commandType: CommandType.StoredProcedure).ToList();

                return productEntity;
            }
        }
           

        public ProductsInCartWithTotalEntity GetCartDetails(Guid UserId)
        {
            using (var connection = _context.CreateConnection())
            {
                ProductsInCartWithTotalEntity producInCarttWithTotalEntity = new ProductsInCartWithTotalEntity();
                List<ProductsInCartEntity> productsInCartEntity = new List<ProductsInCartEntity>();
                               
                string procName = "GetCartDetails";
                var _params = new DynamicParameters();
                _params.Add("@UserId", UserId);
                _params.Add("@TotalPrice", dbType: DbType.Int32, direction: ParameterDirection.Output);

                productsInCartEntity = connection.Query<ProductsInCartEntity>(procName, _params, commandType: CommandType.StoredProcedure).ToList();
                       
                producInCarttWithTotalEntity.productsInCart = productsInCartEntity;
                producInCarttWithTotalEntity.TotalPrice = _params.Get<int>("TotalPrice");

                return producInCarttWithTotalEntity;
            }
        }
    }
}
