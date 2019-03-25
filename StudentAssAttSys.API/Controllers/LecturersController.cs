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
    [RoutePrefix("api/Lecturer")]
    public class LecturersController : ApiController
    {
        //Repository
        IGenericRepository<Lecturer, string> Repository { get; set; }

        public LecturersController()
        {
            Repository = new LecturerRepository();
        }

        // GET: api/Lecturers
        /**
         * <summary>Return the list of all Lecturers</summary>
         */
        [Route("~/api/Lecturers")]
        [ResponseType(typeof(Lecturer[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Lecturer[] lecturers = Repository.GetAll();
            return Content(HttpStatusCode.OK, lecturers);
        }

        // GET: api/Lecturer/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(Lecturer))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            Lecturer lecturer = Repository.GetById(id);

            if (lecturer == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, lecturer);
        }


        // POST: api/Lecturer/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(Lecturer))]
        [HttpPost]
        public IHttpActionResult Post(string id, [FromBody]Lecturer lecturer)
        {
            lecturer.Id = id;

            bool result = Repository.Edit(lecturer);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            lecturer = Repository.GetById(id);

            return Content(HttpStatusCode.OK, lecturer);
        }

        // PUT: api/Lecturer
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(Lecturer))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Lecturer lecturer)
        {
            string lecturerId = Repository.Add(lecturer);

            if (string.IsNullOrEmpty(lecturerId))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            lecturer = Repository.GetById(lecturerId);

            return Content(HttpStatusCode.Created, lecturer);
        }

        // DELETE: api/Lecturer/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            Lecturer lecturer = Repository.GetById(id);
            if (lecturer == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(lecturer))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }
    }
}
