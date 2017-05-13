

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class Schedule : IEntityBase
    {
        public int ID { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public string UserID { get; set; }
        public int ContactInfoDetails_ID { get; set; }
        //public virtual ContactInfo ContactInfoDetails { get; set; }
    }
}
