using StudentAssAttSys.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentAssAttSys.API.Controllers
{
    /**
    * <summary></summary>
    * <returns></returns>
    */
    [Authorize]
    [RoutePrefix("api/Modules")]
    public class ModulesController : ApiController
    {
        // GET: api/Modules
        /**
         * <summary>Return the list of all Modules</summary>
         */
        [Route("")]
        [ResponseType(typeof(Module[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return null;
        }
    }
    /**
    * <summary></summary>
    * <returns></returns>
    */
    [Authorize]
    [RoutePrefix("api/Module")]
    public class ModuleController : ApiController
    {
        // GET: api/Modules/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return null;
        }


        // POST: api/Module/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody]Module module)
        {
            return null;
        }

        // PUT: api/Module
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]string value)
        {
            return null;
        }

        // DELETE: api/Modules/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return null;
        }
    }
}
