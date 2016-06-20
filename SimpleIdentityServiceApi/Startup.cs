using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(SimpleIdentityServiceApi.Startup))]
namespace SimpleIdentityServiceApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            DataProtectionProvider = app.GetDataProtectionProvider();
        }

        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }


        
    }
}
