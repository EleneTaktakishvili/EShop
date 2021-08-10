using eShop.DataBaseRepository.Db;
using eShop.DataBaseRepository.Db.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace eShop.DataBaseRepository.Repositories
{
    public class CategoryRepository : ICategoryRepository  
    {      

        public ICollection<CategoryEntity> GetAll()
        {           
            ICollection<CategoryEntity> categoryEntity = new List<CategoryEntity>();

            using (eShopDbContext context = new eShopDbContext())
            {
               var categoryDb = (from category in context.Categories
                              select category).ToList();

                foreach (var item in categoryDb)
                {
                    categoryEntity.Add(new CategoryEntity
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DateCreated = item.DateCreated,
                        DateChanged = item.DateChanged,
                        DateDeleted = item.DateDeleted

                    });
                }
            }
            return categoryEntity;
        }

        public CategoryEntity GetCategory(Guid Id)
        {
            CategoryEntity categoryEntity = new CategoryEntity();

            using (eShopDbContext context = new eShopDbContext())
            {
                var categoryDb = (from category in context.Categories
                                  where category.Id == Id
                                  select category).SingleOrDefault();

                categoryEntity.Id = categoryDb.Id;
                categoryEntity.Name = categoryDb.Name;
                categoryEntity.DateCreated = categoryDb.DateCreated;
                categoryEntity.DateChanged = categoryDb.DateChanged;
                categoryEntity.DateDeleted = categoryDb.DateDeleted;

            }
            return categoryEntity;
        }

        public bool SaveUpDate(CategoryEntity entity)
        {
            try
            {
                using (eShopDbContext context = new eShopDbContext())
                {
                    //update
                    if (entity.Id != Guid.Empty)
                    {
                        var category = (from item in context.Categories
                                        where item.Id == entity.Id
                                        select item).FirstOrDefault();

                        category.Name = entity.Name;
                    }//add
                    else
                    {
                        Categories categoryDb = new Categories();
                        categoryDb.Id = entity.Id;
                        categoryDb.Name = entity.Name;
                        categoryDb.DateCreated = entity.DateCreated;
                        categoryDb.DateDeleted = entity.DateDeleted;

                        context.Categories.Add(categoryDb);

                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(Guid Id)
        {
            try
            {
                using (eShopDbContext context = new eShopDbContext())
                {
                    var category = (from item in context.Categories
                                    where item.Id == Id
                                    select item).FirstOrDefault();
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
