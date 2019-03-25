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
    [RoutePrefix("api/Comment")]
    public class CommentsController : ApiController
    {
        IGenericRepository<Comment, int> Repository { get; set; }

        public CommentsController()
        {
            Repository = new CommentRepository();
        }

        // GET: api/Comments
        /**
         * <summary>Return the list of all Comments</summary>
         */
        [Route("~/api/Comments")]
        [ResponseType(typeof(Comment[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Comment[] comments = Repository.GetAll();
            return Content(HttpStatusCode.OK, comments);
        }

        // GET: api/Comment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Comment comment = Repository.GetById(id);

            if (comment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, comment);
        }


        // GET: api/Assessment/5/Result/5/Comments
        [Route("~/api/Assessment/{assessmentId:int}/Result/{studentId:string}/Comments")]
        [ResponseType(typeof(Comment[]))]
        [HttpGet]
        public IHttpActionResult Get(int assessmentId, string studentId)
        {
            Comment[] comments = Repository.GetAll().Where(c => c.AssessmentId == assessmentId && c.StudentId.Equals(studentId)).ToArray();
            return Content(HttpStatusCode.OK, comments);
        }



        // POST: api/Comment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(Comment))]
        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody]Comment comment)
        {
            comment.Id = id;

            bool result = Repository.Edit(comment);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            comment = Repository.GetById(id);

            return Content(HttpStatusCode.OK, comment);
        }

        // PUT: api/Assessment/5/Result/5/Comment
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("~/api/Assessment/{id:int}/Result/{studentId:string}/Comment")]
        [ResponseType(typeof(Comment))]
        [HttpPut]
        public IHttpActionResult Put(int assessmentId, string studentId, [FromBody]Comment comment)
        {
            comment.StudentId = studentId;
            comment.AssessmentId = assessmentId;
            int commentId = Repository.Add(comment);

            if (commentId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            comment = Repository.GetById(commentId);

            return Content(HttpStatusCode.Created, comment);
        }

        // DELETE: api/Comment/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Comment comment = Repository.GetById(id);
            if (comment == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Remove(comment))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, "");
        }
    }
}
