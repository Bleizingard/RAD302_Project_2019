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
    [RoutePrefix("api/Result")]
    public class ResultsController : ApiController
    {
        IGenericRepository<Result, KeyValuePair<int, string>> Repository { get; set; }

        public ResultsController()
        {
            Repository = new ResultRepository();
        }

        // GET: api/Results
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("~/api/Results")]
        [ResponseType(typeof(Result[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Result[] results = Repository.GetAll();

            return Content(HttpStatusCode.OK, results);
        }

        // GET: api/Assessment/5/Results
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("~/api/Assessment/{id:int}/Results")]
        [ResponseType(typeof(Result[]))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Result[] results = Repository.GetAll().Where(r => r.AssessmentId == id).ToArray();

            return Content(HttpStatusCode.OK, results);
        }

        // GET: api/Result/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{assessmentId:int}/{studentId}")]
        [ResponseType(typeof(Result))]
        [HttpGet]
        public IHttpActionResult Get(int assessmentId, string studentId)
        {
            Result result = Repository.GetById(new KeyValuePair<int, string>(assessmentId, studentId));

            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, result);
        }

        // PUT: api/Result
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(Result))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Result result)
        {
            KeyValuePair<int, string> resultId = Repository.Add(result);

            if (resultId.Key != result.AssessmentId || !resultId.Value.Equals(result.StudentId))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            result = Repository.GetById(resultId);

            return Content(HttpStatusCode.Created, result);
        }

        // POST: api/Result/5/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{assessmentId:int}/{studentId}")]
        [ResponseType(typeof(Result))]
        [HttpPost]
        public IHttpActionResult Post(int assessmentId, string studentId, [FromBody]Result result)
        {
            result.AssessmentId = assessmentId;
            result.StudentId = studentId;

            bool editResult = Repository.Edit(result);

            if (!editResult)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            result = Repository.GetById(new KeyValuePair<int, string>(assessmentId, studentId));

            return Content(HttpStatusCode.OK, result);
        }

        // DELETE: api/Result/5/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(int assessmentId, string studentId)
        {
            Result result = Repository.GetById(new KeyValuePair<int, string>(assessmentId, studentId));
            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(result))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }
    }
}
