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

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    categoryEntity = (from category in context.Categories
            //                      where category.DateDeleted == null
            //                      select new CategoryEntity
            //                      {
            //                          Id = category.Id,
            //                          Name = category.Name,
            //                          DateCreated = category.DateCreated,
            //                          DateChanged = category.DateChanged,
            //                          DateDeleted = category.DateDeleted
            //                      }).ToList();
            //}
            return categoryEntity;
        }
        public CategoryEntity GetCategory(Guid Id)
        {
            CategoryEntity categoryEntity = new CategoryEntity();

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    categoryEntity = (from category in context.Categories
            //                      where category.Id == Id
            //                      select new CategoryEntity
            //                      {
            //                          Id = category.Id,
            //                          Name = category.Name,
            //                          DateCreated = category.DateCreated,
            //                          DateChanged = category.DateChanged,
            //                          DateDeleted = category.DateDeleted
            //                      }).SingleOrDefault();
            //}
            return categoryEntity;
        }
        public bool SaveUpDate(CategoryEntity entity)
        {
            try
            {
                //using (eShopDbContext context = new eShopDbContext())
                //{
                //    //update
                //    if (entity.Id != Guid.Empty)
                //    {
                //        var category = (from item in context.Categories
                //                        where item.Id == entity.Id
                //                        select item).FirstOrDefault();

                //        category.Name = entity.Name;
                //        category.DateChanged = DateTime.Now;
                //    }
                //    //add
                //    else
                //    {
                //        Categories categoryDb = new Categories();
                //        categoryDb.Id = entity.Id;
                //        categoryDb.Name = entity.Name;
                //        categoryDb.DateCreated = DateTime.Now;

                //        context.Categories.Add(categoryDb);
                //    }
                //    context.SaveChanges();
                //}
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCategory(Guid Id)
        {
            try
            {
            //    using (eShopDbContext context = new eShopDbContext())
            //    {
            //        var category = (from item in context.Categories
            //                        where item.Id == Id
            //                        select item).FirstOrDefault();

            //        category.DateDeleted = DateTime.Now;
            //        // context.Categories.Remove(category);
            //        context.SaveChanges();
            //    }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
