using System;
using System.Threading.Tasks;

using PrecompiledSample.Models;

namespace PrecompiledSample.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="ProductService"/> class.
    /// </summary>
    public interface IProductService : IDisposable
    {
        /// <summary>
        /// Gets the product by product Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Returns the product.</returns>
        Task<ProductModel> GetAsync(string productId);

            /// <summary>
        /// Gets the product by product Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Returns the product.</returns>
        Task<ProductModel> GetAsync(Guid productId);

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="model"><see cref="ProductModel"/> object.</param>
        /// <returns>Returns the result code.</returns>
        Task<int> SaveAsync(ProductModel model);
    }
}