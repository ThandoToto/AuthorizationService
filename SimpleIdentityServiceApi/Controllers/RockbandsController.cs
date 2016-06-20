using SimpleIdentityServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleIdentityServiceApi.Controllers
{
    public class RockbandsController : ApiController
    {
        private IObjectContextFactory _objectContextFactory;

        public RockbandsController()
        {
            _objectContextFactory = new LazySingletonObjectContextFactory();
        }

        public IEnumerable<RockBand> Get()
        {
            return _objectContextFactory.Create().GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            RockBand rockband = _objectContextFactory.Create().GetById(id);
            if (rockband == null)
            {
                return NotFound();
            }
            return Ok<RockBand>(rockband);
        }

        [Route("api/rockbands/{id:int:min(0)}/albums")]
        public IHttpActionResult GetAlbums(int id)
        {
            RockBand rockband = _objectContextFactory.Create().GetById(id);
            if (rockband == null)
            {
                return NotFound();
            }
            return Ok<IEnumerable<Album>>(rockband.Albums);
        }
    }
}
