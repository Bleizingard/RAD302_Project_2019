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
    [RoutePrefix("api/Attendance")]
    public class AttendanceController : ApiController
    {
        IAttendanceRepository Repository { get; set; }

        public AttendanceController()
        {
            //Repository = new AttendanceRepository();
        }

        // GET: api/Attendances
        /**
         * <summary>Return the list of all Modules</summary>
         */
        [Route("~/api/Attendances")]
        [ResponseType(typeof(Attendance[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Attendance[] attendances = Repository.GetAll();
            return Content(HttpStatusCode.OK, attendances);
        }

        // GET: api/Attendance/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(Attendance))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Attendance attendance = Repository.GetById(id);

            if (attendance == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            return Content(HttpStatusCode.OK, attendance);
        }

        // POST: api/Attendance/5
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}")]
        [ResponseType(typeof(Attendance))]
        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody]Attendance attendance)
        {
            attendance.Id = id;

            bool result = Repository.Edit(attendance);

            if (!result)
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            attendance = Repository.GetById(id);

            return Content(HttpStatusCode.OK, attendance);
        }

        // PUT: api/Attendance
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("")]
        [ResponseType(typeof(Attendance))]
        [HttpPut]
        public IHttpActionResult Put([FromBody]Attendance attendance)
        {
            int attendanceId = Repository.Add(attendance);

            if (attendanceId < 1)
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            attendance = Repository.GetById(attendanceId);

            return Content(HttpStatusCode.Created, attendance);
        }

        // POST: api/Attendance/5/Open
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}/Open")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPost]
        public IHttpActionResult OpenAttendance(int id, [FromBody]DateTime endDateTime)
        {
            Attendance attendance = Repository.GetById(id);

            if (attendance == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Open(id, endDateTime))
            {
                return Content(HttpStatusCode.BadRequest, "");
            }

            return Content(HttpStatusCode.OK, attendance);
        }

        // POST: api/Attendance/5/Close
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}/Close")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPost]
        public IHttpActionResult CloseAttendance(int id)
        {
            Attendance attendance = Repository.GetById(id);

            if (attendance == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }

            if (!Repository.Close(id))
            {
                return Content(HttpStatusCode.InternalServerError, "");
            }

            return Content(HttpStatusCode.OK, attendance);
        }

        // POST: api/Attendance/5/Present
        /**
         * <summary></summary>
         * <returns></returns>
         */
        [Route("{id:int}/Present")]
        [ResponseType(typeof(HttpStatusCode))]
        [HttpPost]
        public IHttpActionResult Present(int id)
        {
            throw new NotImplementedException();
        }
    }
}
