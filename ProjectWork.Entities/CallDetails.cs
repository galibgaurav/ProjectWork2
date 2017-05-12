using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class CallDetails : IEntityBase
    {
       
        public int ID { get; set; }
        public TimeSpan CallDuration { get; set; }
        public short CallStatus { get; set; }
      
    }
}
