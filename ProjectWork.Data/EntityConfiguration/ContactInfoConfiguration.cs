using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Data
{
    public class ContactInfoConfiguration: EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(100);
            Property(c => c.PrimaryEmail).IsRequired().HasMaxLength(200);
            Property(c => c.SecondaryEmail).HasMaxLength(200);
            Property(c => c.AddressPermanent).HasMaxLength(250);
            Property(c => c.AddressCorrespondance).HasMaxLength(250);
            Property(c => c.ContactedCreated).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed); 
            Property(c => c.PrimaryContactNumber).IsRequired().HasMaxLength(10);
            Property(c => c.SecondaryContactNumber).HasMaxLength(10);
        }
    }
}
