using eShop.DataBaseRepository.Db;
using eShop.DomainService.RepositoriInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private eShopDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(eShopDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public bool Insert(T obj)
        {
            try
            {
                table.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Update(T obj)
        {
            try
            {
                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
