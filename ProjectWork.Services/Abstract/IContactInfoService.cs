using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Services
{
    public interface IContactInfoService
    {
       Task<string> AddContactInfo(ICollection<ContactInfo> ContactInfos);
    }
}
