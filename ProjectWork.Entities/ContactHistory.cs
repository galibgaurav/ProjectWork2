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
        public string CallStatus { get; set; }
        public string CallRemark { get; set; }
        public DateTime CallTime { get; set; }
    }
}
