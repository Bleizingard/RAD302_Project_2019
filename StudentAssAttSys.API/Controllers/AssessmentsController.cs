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
        [ResponseType(typeof(Assessment))]
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
        [ResponseType(typeof(Assessment))]
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
        [ResponseType(typeof(Assessment))]
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
    }
}
