using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
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
    [RoutePrefix("api/Classes")]
    public class ClassesController : ApiController
    {
        //Repository
        IGenericRepository<ClassGroup, int> Repository { get; set; }

        public ClassesController()
        {
            //Repository = new ClassGroupRepository();
        }

        // GET: api/Classes
        /**
         * <summary>Return the list of all ClassGroups</summary>
         */
        [Route("")]
        [ResponseType(typeof(ClassGroup[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ClassGroup[] classGroups = Repository.GetAll();
            return Content(HttpStatusCode.OK, classGroups);
        }
    }

    /**
    * <summary></summary>
    * <returns></returns>
    */
    [Authorize]
    [RoutePrefix("api/Class")]
    public class ClassController : ApiController
    {
        //Repository
        IGenericRepository<ClassGroup, int> Repository { get; set; }

        public ClassController()
        {
            //Repository = new ClassGroupRepository();
        }

        // GET: api/Class/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(ClassGroup))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ClassGroup classGroup = Repository.GetById(id);

            if (classGroup == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, classGroup);
        }


        // POST: api/Class/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(ClassGroup))]
        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody]ClassGroup classGroups)
        {
            classGroups.Id = id;

            bool result = Repository.Edit(classGroups);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            classGroups = Repository.GetById(id);

            return Content(HttpStatusCode.OK, classGroups);
        }

        // PUT: api/Class
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(ClassGroup))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]ClassGroup classGroups)
        {
            int moduleId = Repository.Add(classGroups);

            if (moduleId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            classGroups = Repository.GetById(moduleId);

            return Content(HttpStatusCode.Created, classGroups);
        }

        // DELETE: api/Class/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ClassGroup classGroups = Repository.GetById(id);
            if (classGroups == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(classGroups))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }
    }
}
