using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PrecompiledSample.EntityModels
{
    /// <summary>
    /// This represents the database context entity for Azure resources cost monitoring.
    /// </summary>
    public class PrecompiledDbContext : DbContext, IPrecompiledDbContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="PrecompiledDbContext"/> class.
        /// </summary>
        static PrecompiledDbContext()
        {
            Database.SetInitializer<PrecompiledDbContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrecompiledDbContext"/> class.
        /// </summary>
        public PrecompiledDbContext()
            : base("Name=PrecompiledDbContext")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrecompiledDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">DB connection string.</param>
        public PrecompiledDbContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Gets or sets the set of <see cref="Product"/> records.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <remarks>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// The task result contains the number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        public override async Task<int> SaveChangesAsync()
        {
            if (this.Database.Connection.State != ConnectionState.Open)
            {
                await this.Database.Connection.OpenAsync().ConfigureAwait(false);
            }

            var transaction = this.Database.BeginTransaction();
            try
            {
                var result = await base.SaveChangesAsync().ConfigureAwait(false);
                transaction.Commit();

                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (this.Database.Connection.State != ConnectionState.Closed)
                {
                    this.Database.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Called when the model is being created.
        /// </summary>
        /// <param name="builder"><see cref="DbModelBuilder"/> instance that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ProductMap());
        }
    }
}
