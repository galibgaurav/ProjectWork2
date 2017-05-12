using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
namespace ProjectWork.Data.EntityConfiguration
{
    

    public class StateConfiguration : EntityTypeConfiguration<State>
    {

        public StateConfiguration()
        {
            
            Property(c => c.StateName).IsRequired().HasMaxLength(20);
          
        }
    }
}
