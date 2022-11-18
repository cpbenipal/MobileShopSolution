
using webMobileShop.Contracts;
using webMobileShop.Models;
using System.Linq;

namespace webMobileShop.Repositories
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly IGenericRepository<UserRolesMapping> _repositoryBase;

        public UserRoleManager(IGenericRepository<UserRolesMapping> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public UserRolesMapping GetUserRoleByUserLoginId(int userId)
        {
            var userRole = _repositoryBase.GetAll().FirstOrDefault(x => x.UserID == userId);
            return userRole;
        }

        public UserRolesMapping InsertUserRole(UserRolesMapping userRole)
        {
            var addedUserRole = _repositoryBase.Insert(userRole);
            _repositoryBase.Save();
            return addedUserRole;
        }
    } 
}
