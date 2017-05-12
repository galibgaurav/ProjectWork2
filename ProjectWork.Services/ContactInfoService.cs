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
                    //ContactInfo ci = new ContactInfo();
                    //ci.Name = item.Name;

                    //ci.PrimaryEmail = item.PrimaryEmail;
                    //ci.SecondaryEmail = item.SecondaryEmail;
                    //ci.AddressPermanent = item.AddressPermanent;
                    //ci.AddressCorrespondance = item.AddressCorrespondance;
                    //ci.PrimaryContactNumber = item.PrimaryContactNumber;
                    //ci.SecondaryContactNumber = item.SecondaryContactNumber;
                    _contactInfoRepository.Add(item);
                }
            
            _unitOfWork.Commit();
            await Task.Delay(1000);
             return "hai";
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        
    }
}
