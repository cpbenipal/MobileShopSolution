using webMobileShop.Contracts;
using webMobileShop.Models;
using System.Collections.Generic;
using System.Linq; 
namespace webMobileShop.Repositories
{
    public class UsersManager : IUserManager
    {
        private readonly IGenericRepository<User> _repositoryBase;

        public UsersManager(IGenericRepository<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public List<User> GetUsers()
        {
            return _repositoryBase.GetAll().ToList();
        }

        public User InsertUser(User user) 
        {
            _repositoryBase.Insert(user);
            _repositoryBase.Save();
            return user;
        }

        public User UpdateUser(User user)
        { 
            var result = _repositoryBase.Update(user);
            _repositoryBase.Save();
            return result;
        }
        public User GetUserByEmail(string Email) 
        {
            return _repositoryBase.GetAll().FirstOrDefault(x => x.Email == Email);
        }
        public User GetUserById(long UserId)
        {
            return _repositoryBase.GetAll().FirstOrDefault(x => x.Id == UserId);
        }
    }
}