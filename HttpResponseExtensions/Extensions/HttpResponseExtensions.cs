using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HttpResponseExtensions.Extensions
{
    /// <summary>
    /// A collection of HttpResponse extensions.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Serializes the object and write it to the response.
        /// </summary>
        /// <param name="httpResponse">The HTTP Response</param>
        /// <param name="obj">The object</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The write response task</returns>
        public static async Task WriteJsonAsync(this HttpResponse httpResponse, object obj, CancellationToken cancellationToken = default)
        {
            httpResponse.ContentType = MediaTypeNames.Application.Json;
            var json = JsonSerializer.Serialize(obj);
            await httpResponse.WriteAsync(json, cancellationToken);
        }
    }
}
