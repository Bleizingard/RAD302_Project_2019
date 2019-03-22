using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using StudentAssAttSys.Infrastructure.Repositories;

namespace StudentAssAttSys.API.Controllers
{
    /**
    * <summary></summary>
    * <returns></returns>
    */
    [Authorize]
    [RoutePrefix("api/Assessment")]
    public class AssessmentsController : ApiController
    {
        //Repository
        IGenericRepository<Assessment, int> Repository { get; set; }

        public AssessmentsController()
        {
            //Repository = new AssessmentRepository();
        }

        // GET: api/Assessments
        /**
         * <summary>Return the list of all Assessments</summary>
         */
        [Route("~/api/Assessments")]
        [ResponseType(typeof(Assessment[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Assessment[] assessments = Repository.GetAll();
            return Content(HttpStatusCode.OK, assessments);
        }

        // GET: api/Assessment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Assessment assessment = Repository.GetById(id);

            if (assessment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, assessment);
        }


        // POST: api/Assessment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody]Assessment assessment)
        {
            assessment.Id = id;

            bool result = Repository.Edit(assessment);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            assessment = Repository.GetById(id);

            return Content(HttpStatusCode.OK, assessment);
        }

        // PUT: api/Assessment
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Assessment assessment)
        {
            int assessmentId = Repository.Add(assessment);

            if (assessmentId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            assessment = Repository.GetById(assessmentId);

            return Content(HttpStatusCode.Created, assessment);
        }

        // DELETE: api/Assessment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Assessment assessment = Repository.GetById(id);
            if (assessment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(assessment))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }

        // GET: api/Assessment/5/result/5/comments
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}/result/{studentId:string}/comments")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpGet]
        public IHttpActionResult GetResultComments(int id, string studentId)
        {
            Assessment assessment = Repository.GetById(id);

            if (assessment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            Result result = assessment.Results.Where(r => r.StudentId == studentId).FirstOrDefault();

            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            Comment[] comments = result.Comments.ToArray();

            return Content(HttpStatusCode.OK, comments);
        }

        // PUT: api/Assessment/5/result/studentId/comment
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}/result/{studentId:string}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPut]
        public IHttpActionResult PutResultComment(int id, string studentId, [FromBody]Comment comment)
        {
            Assessment assessment = Repository.GetById(id);

            if (assessment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            Result result = assessment.Results.Where(r => r.StudentId == studentId).FirstOrDefault();

            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            result.Comments.Add(comment);

            bool edited = Repository.Edit(assessment);

            if (!edited)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            assessment = Repository.GetById(id);

            return Content(HttpStatusCode.Created, assessment);
        }
    }
}
