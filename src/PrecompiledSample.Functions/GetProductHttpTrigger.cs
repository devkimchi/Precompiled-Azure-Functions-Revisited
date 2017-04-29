using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host;

using PrecompiledSample.EntityModels;
using PrecompiledSample.Services;

namespace PrecompiledSample.Functions
{
    /// <summary>
    /// This represents the Azure Functions HTTP Trigger entity for product.
    /// </summary>
    public static class GetProductHttpTrigger
    {
        /// <summary>
        /// Runs the HTTP trigger function.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        /// <returns>Returns the <see cref="HttpResponseMessage"/> instance.</returns>
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var productId = req.GetQueryNameValuePairs()
                               .FirstOrDefault(q => q.Key.Equals("id", StringComparison.CurrentCultureIgnoreCase))
                               .Value;

            var connectionString = ConfigurationManager.ConnectionStrings["PrecompiledDbContext"].ConnectionString;
            var dbContext = new PrecompiledDbContext(connectionString);

            var service = new ProductService(dbContext);

            var product = await service.GetAsync(productId).ConfigureAwait(false);

            return req.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}