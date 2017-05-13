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
    public class ContactInfoService:IContactInfoService
    {
        #region Variables
        private readonly IEntityBaseRepository<ContactInfo> _contactInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public ContactInfoService(IEntityBaseRepository<ContactInfo> contactInfoRepository,IUnitOfWork unitOfWork)
        {
            _contactInfoRepository = contactInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<string> AddContactInfo(ICollection<ContactInfo> ContactInfos)
        {
            try
            {
                foreach (ContactInfo item in ContactInfos)
                {
                    _contactInfoRepository.Add(item);
                }
            
            _unitOfWork.Commit();
            await Task.Delay(1000);
             return "Success";
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactInfo>> GetContactInfo()
        {
            try
            {

                var ContactInfo =_contactInfoRepository.GetAll();
                await Task.Delay(500);
                return ContactInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
