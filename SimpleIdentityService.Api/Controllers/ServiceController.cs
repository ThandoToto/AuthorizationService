using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleIdentityService.Common;
using SimpleIdentityService.Config;
using SimpleIdentityService.Models;
using SimpleIdentityService.Models.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SimpleIdentityService.Api.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {
        IIdentityService _service;

        public ServiceController()
        {
            string server = ConfigurationManager.AppSettings["emailserver"];
            string user = ConfigurationManager.AppSettings["emailuser"];
            string password = ConfigurationManager.AppSettings["emailpassword"];
            string fromAddress = ConfigurationManager.AppSettings["emailfrom"];
            var emailsettings = new EmailSetting(server, user, password, fromAddress);
            //_service = service;
            var dbContext = new ServiceDbContext();
            var userStore = new UserStore<ServiceUser>(dbContext);
            var userManager = new ServiceUserManager(userStore, Startup.DataProtectionProvider, emailsettings);

            //var roleStore = new RoleStore<ServiceRole>(dbContext);
            //var roleManager = new ServiceRoleManager(roleStore);

            //_service = new IdentityService(userManager, roleManager);
            _service = new IdentityService(userManager);
        }

        
        [Route("User/{email}")]
        public async Task<IHttpActionResult> GetUser(string email)
        {
            var user = await _service.GetUserByEmail(email);
            return Ok<ServiceUser>(user);
        }

        [HttpPost]
        [Route("user/create")]
        public async Task<IHttpActionResult> CreateUser(User user)
        {
            var result = await _service.CreateUser(user);
            if (result.Succeeded)
                return Ok<IdentityResult>(result);
            else
                return Ok<IdentityResult>(result);

        }


    }
}
