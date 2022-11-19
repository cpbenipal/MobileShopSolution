using webMobileShop.Contracts;
using webMobileShop.Models;

namespace webMobileShop.Repositories
{
    public class RoleManager : IRoleManager
    {
        private readonly IGenericRepository<Role> repositoryBase;

        public RoleManager(IGenericRepository<Role> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public Role GetRole(int roleId)
        {
            return repositoryBase.GetById(roleId);
        }

        public Role InsertRole(Role role)
        {
            var addedRole = repositoryBase.Insert(role);
            repositoryBase.Save();
            return addedRole;
        }
    }
}