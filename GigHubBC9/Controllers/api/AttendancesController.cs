using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHubBC9.Core;
using GigHubBC9.Core.Dtos;
using GigHubBC9.Core.Models;
using GigHubBC9.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHubBC9.Controllers.api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            // edge case
            var attendance = unitOfWork.Attendances.GetAttendance(attendanceDto.GigId, userId);

            if (attendance != null)
                return BadRequest("The attendance already exists");

            attendance = new Attendance
            {
                GigId = attendanceDto.GigId,
                AttendeeId = userId
            };

            unitOfWork.Attendances.Add(attendance);
            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = unitOfWork.Attendances.GetAttendance(id, userId);

            if (attendance == null)
                return NotFound();

            unitOfWork.Attendances.Remove(attendance);
            unitOfWork.Complete();

            return Ok(id);
        }
    }
}
