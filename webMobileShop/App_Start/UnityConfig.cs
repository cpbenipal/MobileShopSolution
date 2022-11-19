using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using webMobileShop.Contracts;
using webMobileShop.Controllers;
using webMobileShop.Interactors;
using webMobileShop.Repositories;

namespace webMobileShop.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; internal set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            //Register the Repository in the Unity Container                         
            container.RegisterType<UserInteractor>();
            container.RegisterType<IUserManager, UsersManager>();
            container.RegisterType<IRepositoryWrapper, RepositoryWrapper>();
            container.RegisterType<IUserRoleManager, UserRoleManager>();
            container.RegisterType<IRoleManager, RoleManager>();
            container.RegisterType<IHashManager, HashManager>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}