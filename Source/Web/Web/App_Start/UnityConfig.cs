using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Web.Service;

namespace Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IHomeService, HomeService>();
            container.RegisterType<ILoginService, LoginService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}