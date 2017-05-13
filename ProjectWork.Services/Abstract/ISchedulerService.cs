using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Services
{
    public interface ISchedulerService
    {
        Task<bool> AddSchedule(IList<Schedule> ScheduleLst);
    }
}
