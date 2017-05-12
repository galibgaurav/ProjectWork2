using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class ContactInfo:IEntityBase
    {
        public ContactInfo()
        {
            ContactHistory = new List<ContactHistory>();

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string  PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string AddressPermanent { get; set; }
        public string AddressCorrespondance { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
        public DateTime? ContactedCreated { get; set; }
        public DateTime? ContactedUpdated { get; set; }

        public virtual ICollection<ContactHistory> ContactHistory { get; set; }
        public virtual State state { get; set; }
    }
}
