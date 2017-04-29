using System;

namespace PrecompiledSample.EntityModels
{
    /// <summary>
    /// This represents the database entity for product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product Id.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the date when the record was created.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date when the record was updated.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }
    }
}