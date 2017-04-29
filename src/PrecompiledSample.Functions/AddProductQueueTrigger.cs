using System.Configuration;

using Microsoft.Azure.WebJobs.Host;

using Newtonsoft.Json;

using PrecompiledSample.EntityModels;
using PrecompiledSample.Models;
using PrecompiledSample.Services;

namespace PrecompiledSample.Functions
{
    /// <summary>
    /// This represents the Azure Function Queue Trigger entity for product.
    /// </summary>
    public static class AddProductQueueTrigger
    {
        /// <summary>
        /// Runs the Queue Trigger function.
        /// </summary>
        /// <param name="myQueueItem">Queue message.</param>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        public static async void Run(string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");

            var model = JsonConvert.DeserializeObject<ProductModel>(myQueueItem);

            var connectionString = ConfigurationManager.ConnectionStrings["PrecompiledDbContext"].ConnectionString;
            var dbContext = new PrecompiledDbContext(connectionString);

            var service = new ProductService(dbContext);

            var result = await service.SaveAsync(model).ConfigureAwait(false);

            log.Info("Queue has been processed");
        }
    }
}