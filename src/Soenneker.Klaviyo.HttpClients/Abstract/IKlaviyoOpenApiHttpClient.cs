using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Klaviyo.HttpClients.Abstract;

/// <summary>
/// A cached HTTP transport for Klaviyo. Authentication is attached by the OpenAPI client utility.
/// </summary>
public interface IKlaviyoOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>Gets the shared HTTP transport using Klaviyo:ClientBaseUrl. Configure the base URL before first use.</summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
