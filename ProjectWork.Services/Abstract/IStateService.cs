using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Services
{
    public interface IStateService
    {
        Task<bool> UpdateStatus(State state);
        Task<IQueryable<State>> GetStatus(int ContactInfoDetails_ID);
    }
}
