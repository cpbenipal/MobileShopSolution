using webMobileShop.Contracts;
using webMobileShop.Models; 

namespace webMobileShop.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbMobileShopEntities _repoContext;

        public RepositoryWrapper(DbMobileShopEntities context)
        {
            _repoContext = context;
        }

        private IUserManager _UserManager;
        public IUserManager UserManager 
        {
            get
            {

                if (_UserManager == null)
                {
                    var repositorybase = new RepositoryBase<User>(_repoContext);
                    _UserManager = new UsersManager(repositorybase);
                }
                return _UserManager;
            }
        }

        private IRoleManager _roleManager;
        public IRoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                {
                    var repositoryBase = new RepositoryBase<Role>(_repoContext);
                    _roleManager = new RoleManager(repositoryBase);
                }
                return _roleManager;
            }
        }

        private IUserRoleManager _userRoleManager;
        public IUserRoleManager UserRoleManager
        {
            get
            {
                if (_userRoleManager == null)
                {
                    var repositoryBase = new RepositoryBase<UserRolesMapping>(_repoContext);
                    _userRoleManager = new UserRoleManager(repositoryBase);
                }
                return _userRoleManager;
            }
        }
    }
}