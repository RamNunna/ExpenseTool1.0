using ExpenseApp.Business;
using ExpenseApp.Business.Contracts;
using ExpenseApp.Repository;
using ExpenseApp.Repository.Contracts;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace ExpenseApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserManager, UserManager>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}