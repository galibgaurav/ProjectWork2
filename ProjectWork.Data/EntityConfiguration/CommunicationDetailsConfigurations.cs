using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Data.EntityConfiguration
{
    public class CommunicationDetailsConfigurations : EntityTypeConfiguration<CommunicationDetails>
    {
        public CommunicationDetailsConfigurations()
        {
            Property(c => c.communicationTypes).IsRequired();
        }
    }
}
