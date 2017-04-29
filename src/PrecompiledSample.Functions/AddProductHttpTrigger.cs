using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace PrecompiledSample.Functions
{
    /// <summary>
    /// This represents the Azure Functions HTTP Trigger entity for product.
    /// </summary>
    public static class AddProductHttpTrigger
    {
        /// <summary>
        /// Runs the HTTP trigger function.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="outputQueues">Output queue string.</param>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        /// <returns>Returns the <see cref="HttpResponseMessage"/> instance.</returns>
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IAsyncCollector<string> outputQueues, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var body = await req.Content.ReadAsStringAsync().ConfigureAwait(false);

            await outputQueues.AddAsync(body).ConfigureAwait(false);

            return req.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}