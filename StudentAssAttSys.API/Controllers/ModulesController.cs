using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using StudentAssAttSys.Infrastructure.Repositories;
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
        //Repository
        IGenericRepository<Module, int> Repository { get; set; }

        public ModulesController()
        {
            Repository = new ModuleRepository();
        }

        // GET: api/Modules
        /**
         * <summary>Return the list of all Modules</summary>
         */
        [Route("")]
        [ResponseType(typeof(Module[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Module> modules = Repository.GetAll();
            return Content(HttpStatusCode.OK, modules);
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
        //Repository
        IGenericRepository<Module, int> Repository { get; set; }

        public ModuleController()
        {
            Repository = new ModuleRepository();
        }

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
            Module module = Repository.GetById(id);

            if (module == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }
            return Content(HttpStatusCode.OK, module);
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
            module.Id = id;

            bool result = Repository.Edit(module);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            return Content(HttpStatusCode.OK, "");
        }

        // PUT: api/Module
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Module module)
        {
            int moduleId = Repository.Add(module);

            if (moduleId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
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
            Module module = Repository.GetById(id);
            if (module == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if(!Repository.Remove(module))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return null;
        }
    }
}
