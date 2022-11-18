
using webMobileShop.Models;

namespace webMobileShop.Contracts
{
    public interface IRoleManager
    {
        Role InsertRole(Role role);
        Role GetRole(int roleId);
    }
}
