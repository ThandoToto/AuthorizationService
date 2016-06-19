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

namespace SimpleIdentityService.Api
{
    public class Startup
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi(app);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //var container = new Container();
           

            //config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }
    }
}
