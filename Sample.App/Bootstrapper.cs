using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sample.Model.Interfaces;
using Sample.Model.Repositories;
using Unity.Mvc3;

namespace Sample.App
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IAppRepository, AppRepository>();

            return container;
        }
    }
}