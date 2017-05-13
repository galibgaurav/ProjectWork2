using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectWork.Web.Models;
using ProjectWork.Services;
using ProjectWork.Entities;
using AutoMapper;
using System.Collections.ObjectModel;
using ProjectWork.Web.Infrastructure.Core;
using ProjectWork.Data;

namespace ProjectWork.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Schedule")]

    public class ScheduleController : ApiControllerBase
    {
        private readonly ISchedulerService _schedulerService;

        public ScheduleController(ISchedulerService schedulerService, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            :base(_errorsRepository,_unitOfWork)
        {
            _schedulerService = schedulerService;
        }



        [Route("PostSchedule")]
        //[ResponseType(typeof(Schedule))]
        public async Task<IHttpActionResult> PostSchedule(ScheduleViewModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            string dateString = schedule.ScheduleTime;  
            DateTime dtObj = Convert.ToDateTime(schedule.ScheduleTime);

            IList<Schedule> scheduleList = new List<Schedule>();
            foreach(int item in schedule.ContactInfoIDs)
            {
                Schedule scheduleObj = new Schedule();
                scheduleObj.ScheduleTime = dtObj;
                scheduleObj.UserID = schedule.UserID;
                scheduleObj.ContactInfoDetails_ID = item;
                scheduleList.Add(scheduleObj);
            }
            //contactInfoCollection = Mapper.Map<ICollection<ContactInfoModel>, ICollection<ContactInfo>>(contactInfos);
            var result = await _schedulerService.AddSchedule(scheduleList);
            return null;

        }

    }



}
