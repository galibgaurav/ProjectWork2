using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class State : IEntityBase
    {
        //public State()
        //{
        //    ContactHistory = new List<>();
        //}
        public int ID { get; set; }
        public string StateName { get; set; }
        }
}
