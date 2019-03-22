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
    [RoutePrefix("api/Result")]
    public class ResultsController : ApiController
    {
        IGenericRepository<Result, KeyValuePair<int, string>> Repository { get; set; }

        public ResultsController()
        {
            //Repository = new ResultRepository();
        }

        // GET: api/Result/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{assessmentId:int}/{studentId:string}")]
        [ResponseType(typeof(HttpStatusCode))]
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

        // GET: api/Assessment/5/results
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("~/api/Assessment/{id:int}/Results")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpGet]
        public IHttpActionResult GetResults(int id)
        {
           Result[] results = Repository.GetAll();

            return Content(HttpStatusCode.OK, results);
        }
    }
}
