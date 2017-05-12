using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class ContactHistory:IEntityBase
    {
        public int ID { get; set; }
        public DateTime? communicationTime { get; set; }
        public string userID { get; set; }
        public virtual CommunicationDetails communicationDetails { get; set; }
    }
}
