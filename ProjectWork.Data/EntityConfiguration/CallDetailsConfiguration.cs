using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Data.EntityConfiguration
{
    public class CallDetailsConfiguration : EntityTypeConfiguration<CallDetails>
    {
        public CallDetailsConfiguration()
        {
            Property(c => c.CallStatus).IsRequired();
            Property(c => c.CallDuration).IsRequired();
        }
    }
}
