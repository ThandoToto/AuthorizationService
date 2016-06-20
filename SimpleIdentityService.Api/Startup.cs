using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security.Cookies;
using SimpleIdentityService.Api.Controllers;
using System.Reflection;
using SimpleIdentityService.Models;
using Microsoft.AspNet.Identity;
using SimpleIdentityService.Models.Managers;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Practices.Unity;
using Microsoft.AspNet.Identity.Owin;
using SimpleIdentityService.Config;
using System.Configuration;

namespace SimpleIdentityService.Api
{
    public class Startup
    {

        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }



        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            

            var webApiConfiguration = ConfigureWebApi(app);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
            DataProtectionProvider = app.GetDataProtectionProvider();
        }

        private HttpConfiguration ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();

            //UnityConfig.RegisterComponents(config);

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }
    }
}
