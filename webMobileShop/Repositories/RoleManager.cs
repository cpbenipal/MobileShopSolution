using webMobileShop.Contracts;
using webMobileShop.Models; 
namespace webMobileShop.Repositories
{
    public class RoleManager : IRoleManager
    {
        private readonly IGenericRepository<Role> _repositoryBase;

        public RoleManager(IGenericRepository<Role> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public Role GetRole(int roleId)
        {
            return _repositoryBase.GetById(roleId);
        }

        public Role InsertRole(Role role)
        {
            var addedRole = _repositoryBase.Insert(role);
            _repositoryBase.Save();
            return addedRole;
        }

    }
}