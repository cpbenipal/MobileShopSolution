
using webMobileShop.Models;

namespace webMobileShop.Contracts
{
    public interface IUserRoleManager
    {
        UserRolesMapping GetUserRoleByUserLoginId(int userId);
        UserRolesMapping InsertUserRole(UserRolesMapping userRole);
    }
}
