using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectWork.Data
{
    public class ContactHistoryConfiguration: EntityTypeConfiguration<ContactHistory>
    {
        
        public ContactHistoryConfiguration()
        {
           
            Property(c => c.communicationTime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(c => c.userID).IsRequired().HasMaxLength(32);
           
        }
    }
}
