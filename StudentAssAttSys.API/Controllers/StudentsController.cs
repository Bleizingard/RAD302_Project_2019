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
    [RoutePrefix("api/Student")]
    public class StudentsController : ApiController
    {
        //Repository
        IGenericRepository<Student, string> Repository { get; set; }

        public StudentsController()
        {
            Repository = new StudentRepository();
        }

        // GET: api/Students
        /**
         * <summary>Return the list of all Students</summary>
         */
        [Route("~/api/Students")]
        [ResponseType(typeof(Student[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Student[] students = Repository.GetAll();
            return Content(HttpStatusCode.OK, students);
        }

        // GET: api/Student/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(Student))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            Student student = Repository.GetById(id);

            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, student);
        }


        // POST: api/Student/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(Student))]
        [HttpPost]
        public IHttpActionResult Post(string id, [FromBody]Student student)
        {
            student.Id = id;

            bool result = Repository.Edit(student);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            student = Repository.GetById(id);

            return Content(HttpStatusCode.OK, student);
        }

        // PUT: api/Student
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(Student))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Student student)
        {
            string studentId = Repository.Add(student);

            if (string.IsNullOrEmpty(studentId))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            student = Repository.GetById(studentId);

            return Content(HttpStatusCode.Created, student);
        }

        // DELETE: api/Student/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:string}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            Student student = Repository.GetById(id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(student))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }
    }
}
