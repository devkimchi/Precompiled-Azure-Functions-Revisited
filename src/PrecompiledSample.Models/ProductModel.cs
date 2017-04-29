using System;

namespace PrecompiledSample.Models
{
    /// <summary>
    /// This represents the model entity for product.
    /// </summary>
    public class ProductModel
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
    }
}
