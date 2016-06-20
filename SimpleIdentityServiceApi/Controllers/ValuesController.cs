using SimpleIdentityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleIdentityServiceApi.Controllers
{
    public class ValuesController : ApiController
    {
        IIdentityService _service;
        public ValuesController(IIdentityService service)
        {
            _service = service;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var user = _service.GetUserByEmail("t@m.com").Result;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
