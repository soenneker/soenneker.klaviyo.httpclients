using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Klaviyo.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Klaviyo.HttpClients;

public sealed class KlaviyoOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration configuration) : IKlaviyoOpenApiHttpClient
{
    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        string? configuredUrl = configuration["Klaviyo:ClientBaseUrl"] ?? "https://a.klaviyo.com";
        if (!Uri.TryCreate(configuredUrl, UriKind.Absolute, out Uri? baseAddress) ||
            baseAddress.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(baseAddress.UserInfo) ||
            !string.IsNullOrEmpty(baseAddress.Query) || !string.IsNullOrEmpty(baseAddress.Fragment))
            throw new InvalidOperationException("Klaviyo:ClientBaseUrl must be an absolute HTTPS API base URL without credentials, query, or fragment.");

        return httpClientCache.Get(nameof(KlaviyoOpenApiHttpClient), baseAddress, static address => new HttpClientOptions
        {
            BaseAddress = new Uri(address.AbsoluteUri.TrimEnd('/') + "/"),
            DefaultRequestHeaders = new Dictionary<string, string> { ["Accept"] = "application/vnd.api+json" }
        }, cancellationToken);
    }

    public void Dispose() => httpClientCache.RemoveSync(nameof(KlaviyoOpenApiHttpClient));

    public ValueTask DisposeAsync() => httpClientCache.Remove(nameof(KlaviyoOpenApiHttpClient));
}
