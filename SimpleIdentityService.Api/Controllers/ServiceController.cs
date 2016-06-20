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

            _service = new IdentityService(new ServiceUserManager(new UserStore<ServiceUser>(new ServiceDbContext()), Startup.DataProtectionProvider, emailsettings));

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
