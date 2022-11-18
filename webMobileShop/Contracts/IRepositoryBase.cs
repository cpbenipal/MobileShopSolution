using System.Collections.Generic;

namespace webMobileShop.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Insert(T obj);
        T Update(T obj);
        void Delete(object id);
        void Save();
    }
}
