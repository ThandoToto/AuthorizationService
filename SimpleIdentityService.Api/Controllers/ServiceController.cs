using SimpleIdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleIdentityService.Api.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {
        IIdentityService _service;

        public ServiceController(IIdentityService service)
        {
            _service = service;
        }

        [Route("User")]
        public async Task<IHttpActionResult> GetUser(string email)
        {
            var user = await _service.GetUserByEmail(email);
            return Ok<ServiceUser>(user);
        } 
    }
}
