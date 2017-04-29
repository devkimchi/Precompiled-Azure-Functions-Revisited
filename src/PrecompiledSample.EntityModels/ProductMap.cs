using System.Data.Entity.ModelConfiguration;

namespace PrecompiledSample.EntityModels
{
    /// <summary>
    /// This represents the mapping entity for the <see cref="Product"/> class.
    /// </summary>
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMap"/> class.
        /// </summary>
        public ProductMap()
        {
            // Primary Key
            this.HasKey(p => p.ProductId);

            // Properties
            this.Property(p => p.ProductId).IsRequired();
            this.Property(p => p.Name).IsRequired().HasMaxLength(128);
            this.Property(p => p.Description).IsOptional().HasMaxLength(int.MaxValue);
            this.Property(p => p.UnitPrice).IsRequired();
            this.Property(p => p.DateCreated).IsRequired();
            this.Property(p => p.DateUpdated).IsRequired();

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(p => p.ProductId).HasColumnName("ProductId");
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.Description).HasColumnName("Description");
            this.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
            this.Property(p => p.DateCreated).HasColumnName("DateCreated");
            this.Property(p => p.DateUpdated).HasColumnName("DateUpdated");

            // Relationships
        }
    }
}