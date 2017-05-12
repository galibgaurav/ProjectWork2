using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectWork.Data
{
   public class ProjectWorkContext :DbContext
    {
        public ProjectWorkContext():
            base("ProjectWork")
        {
            Database.SetInitializer<ProjectWorkContext>(null);
        }
        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public DbSet<ContactInfo> ContactInfoSet { get; set; }
        public IDbSet<ContactHistory> ContactHistorySet { get; set; }
        public DbSet<State> StateSet { get; set; }
        public DbSet <CommunicationDetails> CommunicationDetailsSet { get; set; }
        public DbSet <CallDetails> CallDetails { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ContactHistoryConfiguration());
            modelBuilder.Configurations.Add(new ContactInfoConfiguration());

        }
    }
}
