using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleIdentityService;
using SimpleIdentityService.Common;
using SimpleIdentityService.Config;
using SimpleIdentityService.Models;
using SimpleIdentityService.Models.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleIdentityServiceApi.Controllers
{
    [RoutePrefix("api/service")]
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

        [Route("user/{email}")]
        public async Task<IHttpActionResult> GetUser(string email)
        {
            var user = await _service.GetUserByEmail(email);
            return Ok<ServiceUser>(user);
        }

        [HttpPost]
        [Route("user/create")]
        public async Task<IHttpActionResult> GetUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result =  _service.CreateUser(user);
                    return Ok<IdentityResult>(result);
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            
        }

    }
}
