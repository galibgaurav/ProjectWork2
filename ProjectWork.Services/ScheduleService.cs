using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using ProjectWork.Data;
using ProjectWork.Data.Extensions;
using System.Security.Principal;
 
namespace ProjectWork.Services
{
    public class ScheduleService : ISchedulerService
    {
        #region Variables
        private readonly IEntityBaseRepository<Schedule> _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public ScheduleService(IEntityBaseRepository<Schedule> scheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddSchedule(IList<Schedule> ScheduleLst)
        {
            try
            {
                foreach (Schedule item in ScheduleLst)
                {
                    _scheduleRepository.Add(item);
                   
                }

                _unitOfWork.Commit();
                await Task.Delay(1000);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
