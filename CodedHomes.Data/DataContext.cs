using CodedHomes.Data.Configuration;
using CodedHomes.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace CodedHomes.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public static string ConnectionStringName
        {
            get 
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] 
                    != null)
                {
                    return ConfigurationManager.
                        AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        //public DataContext()
        //    : base(nameOrConnectionString: DataContext.ConnectionStringName) {}

         public DataContext()
            : base(nameOrConnectionString: "CodedHomesDEMO") { }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            // Add ASP.NET WebPages SimpleSecurity tables
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        private void ApplyRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                        .Where(
                             e => e.Entity is IAuditInfo &&
                            (e.State == EntityState.Added) || 
                            (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = DateTime.Now;
                }

                e.ModifiedOn = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyRules();

            return base.SaveChanges();
        }
    }
}