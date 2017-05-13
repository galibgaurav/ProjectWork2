using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Data.EntityConfiguration
{
    public class SchduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public SchduleConfiguration()
        {
            Property(x => x.ScheduleTime).IsRequired();
            Property(x => x.UserID).IsRequired().HasMaxLength(32);
            Property(x => x.ContactInfoDetails_ID).IsRequired();
            //Property(x => x.ContactInfoDetails.ID).IsRequired();
            //Property(x => x.ContactInfoDetails.Name).IsOptional();
            //Property(x => x.ContactInfoDetails.PrimaryContactNumber).IsOptional();
            //Property(x => x.ContactInfoDetails.PrimaryEmail).IsOptional();
            
            
        }

    }
}
