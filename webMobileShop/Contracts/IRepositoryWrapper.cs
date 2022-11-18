namespace webMobileShop.Contracts
{
    public interface IRepositoryWrapper
    {
       IUserManager UserManager { get; }
        IRoleManager RoleManager { get; }
        IUserRoleManager UserRoleManager { get; }
    } 
}
