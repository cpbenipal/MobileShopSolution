using webMobileShop.Models;
using System.Collections.Generic; 

namespace webMobileShop.Contracts
{
    public interface IUserManager 
    {
        List<User> GetUsers();  
        User InsertUser(User user);
        User UpdateUser(User user);
        User GetUserByEmail(string Email);
        bool CheckIfEmailExists(string Email);
        bool CheckIfValidActivationCode(string Code);
        User GetUserById(long UserId);
        User GetUserByCode(string Code);  
    } 
}
