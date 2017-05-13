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
    public class StateService : IStateService
    {
        #region Variables
        private readonly IEntityBaseRepository<State> _stateRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public StateService(IEntityBaseRepository<State> stateRepository, IUnitOfWork unitOfWork)
        {
            _stateRepository = stateRepository;
            _unitOfWork = unitOfWork;
        }

       public async Task<bool> UpdateStatus(State state)
        {
            try
            {
                _stateRepository.Add(state);
                _unitOfWork.Commit();
                await Task.Delay(1000);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IQueryable<State>> GetStatus(int ContactInfoDetails_ID)
        {
            try
            {
                var result =_stateRepository.FindBy(x=>x.ContactInfoDetails_ID==ContactInfoDetails_ID);
                _unitOfWork.Commit();
                await Task.Delay(1000);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}


