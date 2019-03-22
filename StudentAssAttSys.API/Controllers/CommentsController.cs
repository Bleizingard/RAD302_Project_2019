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
    [RoutePrefix("api/Assessment/{id:int}/result")]
    public class CommentsController : ApiController
    {
        IGenericRepository<Comment, int> Repository { get; set; }

        public CommentsController()
        {
            //Repository = new CommentRepository();
        }
        // PUT: api/Assessment/5/result/studentId/comment
        /**
         * <summary></summary>
         * <returns></returns>
         */
        
    }
}
