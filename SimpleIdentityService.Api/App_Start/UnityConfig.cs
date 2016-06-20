using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;
using SimpleIdentityService.Config;
using SimpleIdentityService.Models;
using SimpleIdentityService.Models.Managers;
using System.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace SimpleIdentityService.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			//var container = new UnityContainer();

            //string server = ConfigurationManager.AppSettings["emailserver"];
            //string user = ConfigurationManager.AppSettings["emailuser"];
            //string password = ConfigurationManager.AppSettings["emailpassword"];
            //string fromAddress = ConfigurationManager.AppSettings["emailfrom"];

            //container.RegisterType<IEmailSetting, EmailSetting>(new InjectionConstructor(server, user, password, fromAddress))
            //    .RegisterType<ServiceDbContext>()
            //    .RegisterType<IUserStore<ServiceUser>, UserStore<ServiceUser>>(
            //        new InjectionConstructor(typeof(ServiceDbContext)))
            //    .RegisterType<IdentityFactoryOptions<ServiceUserManager>>(new InjectionFactory(x =>
            //       new IdentityFactoryOptions<ServiceUserManager>
            //       {
            //           DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            //       }));


            ////container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(
            ////   new InjectionConstructor(typeof(MyDbContext)));
            ////container.RegisterType<IAuthenticationManager>(
            ////   new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            //config.DependencyResolver = new UnityDependencyResolver(container);

            // GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}