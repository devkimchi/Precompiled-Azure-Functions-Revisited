using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrecompiledSample.EntityModels;
using PrecompiledSample.Models;

namespace PrecompiledSample.Services
{
    /// <summary>
    /// This represents the service entity for product.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IPrecompiledDbContext _context;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="context"><see cref="IPrecompiledDbContext"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <see langword="null"/></exception>
        public ProductService(IPrecompiledDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this._context = context;
        }

        /// <summary>
        /// Gets the product by product Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Returns the product.</returns>
        public async Task<ProductModel> GetAsync(string productId)
        {
            var id = Guid.Parse(productId);

            return await this.GetAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the product by product Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Returns the product.</returns>
        public async Task<ProductModel> GetAsync(Guid productId)
        {
            var product = await this._context.Products
                                    .Select(
                                            p => new ProductModel()
                                                     {
                                                         ProductId = p.ProductId,
                                                         Name = p.Name,
                                                         Description = p.Description,
                                                         UnitPrice = p.UnitPrice
                                                     })
                                    .SingleOrDefaultAsync(p => p.ProductId == productId)
                                    .ConfigureAwait(false);

            return product;
        }

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="model"><see cref="ProductModel"/> object.</param>
        /// <returns>Returns the result code.</returns>
        public async Task<int> SaveAsync(ProductModel model)
        {
            var now = DateTimeOffset.UtcNow;

            var product = await this._context.Products
                                    .SingleOrDefaultAsync(p => p.ProductId == model.ProductId)
                                    .ConfigureAwait(false);

            if (product == null)
            {
                product = new Product() { ProductId = Guid.NewGuid(), DateCreated = now };
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.UnitPrice = model.UnitPrice;
            product.DateUpdated = now;

            this._context.Products.Add(product);

            var result = await this._context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
