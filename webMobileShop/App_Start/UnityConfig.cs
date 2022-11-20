using System.Linq;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using webMobileShop.Contracts;
using webMobileShop.Controllers;
using webMobileShop.Interactors;
using webMobileShop.Models;
using webMobileShop.Repositories;

namespace webMobileShop.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; set; }

        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            //Register the Repository in the Unity Container                         
            RegisterRepositories();
            RegisterUnityFilters();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }

        private static void RegisterRepositories()
        {
            Container.RegisterType<UserInteractor>();
            Container.RegisterType<IUserManager, UsersManager>();
            Container.RegisterType<IRepositoryWrapper, RepositoryWrapper>();
            Container.RegisterType<IUserRoleManager, UserRoleManager>();
            Container.RegisterType<IRoleManager, RoleManager>();
            Container.RegisterType<IHashManager, HashManager>();
        }

        private static void RegisterUnityFilters()
        {
            var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            var provider = new UnityFilterAttributeFilterProvider(Container);
            FilterProviders.Providers.Add(provider);
        }
    }
}