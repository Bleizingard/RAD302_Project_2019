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
    [RoutePrefix("api/Assessments")]
    public class AssessmentsController : ApiController
    {
        //Repository
        IGenericRepository<Assessment, int> Repository { get; set; }

        public AssessmentsController()
        {
            Repository = new AssessmentRepository();
        }

        // GET: api/Assessments
        /**
         * <summary>Return the list of all Assessments</summary>
         */
        [Route("")]
        [ResponseType(typeof(Assessment[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Assessment[] assessments = Repository.GetAll();
            return Content(HttpStatusCode.OK, assessments);
        }
    }
}
