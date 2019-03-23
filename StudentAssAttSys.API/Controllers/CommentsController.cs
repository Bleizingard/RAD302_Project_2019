using StudentAssAttSys.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAssAttSys.Infrastructure.Repositories;
using StudentAssAttSys.Core.IRepositories;
using System.Web.Http.Description;

namespace StudentAssAttSys.API.Controllers
{
    /**
    * <summary></summary>
    * <returns></returns>
    */
    [Authorize]
    [RoutePrefix("api/Assessment/{id:int}/Result/{studentId}/Comments")]
    public class CommentsController : ApiController
    {
        IGenericRepository<Comment, int> Repository { get; set; }

        public CommentsController()
        {
            //Repository = new CommentRepository();
        }

        // GET: api/Assessment/5/Result/studentId/Comments
        [Route("")]
        [ResponseType(typeof(Module[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Comment[] comments = Repository.GetAll();
            return Content(HttpStatusCode.OK, comments);
        }

        // PUT: api/Assessment/5/Result/studentId/Comment
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("api/Assessment/{id:int}/Result/{studentId}/Comment")]
        [ResponseType(typeof(Comment))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Comment comment)
        {
            int commentId = Repository.Add(comment);

            if (commentId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            comment = Repository.GetById(commentId);

            return Content(HttpStatusCode.Created, comment);
        }
    }
}
