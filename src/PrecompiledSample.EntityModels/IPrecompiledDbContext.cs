using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PrecompiledSample.EntityModels
{
    /// <summary>
    /// This provides interfaces to the <see cref="PrecompiledDbContext"/> class.
    /// </summary>
    public interface IPrecompiledDbContext : IDisposable
    {
        /// <summary>
        /// Gets or sets the set of <see cref="Product"/> records.
        /// </summary>
        DbSet<Product> Products { get; set; }

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
        Task<int> SaveChangesAsync();
    }
}