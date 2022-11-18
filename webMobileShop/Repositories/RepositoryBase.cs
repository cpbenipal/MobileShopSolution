using webMobileShop.Contracts;
using webMobileShop.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq; 

namespace webMobileShop.Repositories
{
    public class RepositoryBase<T> : IGenericRepository<T> where T : class
    {
        private readonly DbMobileShopEntities _context;
        private readonly DbSet<T> table;
        public RepositoryBase()
        {
            this._context = new DbMobileShopEntities();
            table = _context.Set<T>();
        }
        public RepositoryBase(DbMobileShopEntities _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public T Insert(T obj)
        {
            table.Add(obj);
            return obj;
        }
        public T Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}