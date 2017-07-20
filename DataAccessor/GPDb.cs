using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using DataContracts;
using EntityFrameworkHelper;

namespace DataAccessor
{
    public class GPDb : DbContext
    {
        #region DbSets
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

#endregion
        public bool SoftDeleteFilterIsActive { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<Attendee>().ToTable("Attendee");

            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>("SoftDeleteColumnName",
               (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(conv);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        public GPDb(UserContext userContext)
        {
            SoftDeleteFilterIsActive = true;

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            EntityConnectionStringBuilder connectionString = new EntityConnectionStringBuilder();
            connectionString.Provider = "System.Data.SqlClient";
            connectionString.ProviderConnectionString = userContext.ConnectionString;

            Database.Connection.ConnectionString = connectionString.ProviderConnectionString;
            Database.SetInitializer<GPDb>(null);
        }

    }
}
