
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class CommunicationDetails : IEntityBase
    {
        
        public int ID { get; set; }
        public short communicationTypes { get; set; }
        public virtual CallDetails callDetails { get; set; }
    }
}
