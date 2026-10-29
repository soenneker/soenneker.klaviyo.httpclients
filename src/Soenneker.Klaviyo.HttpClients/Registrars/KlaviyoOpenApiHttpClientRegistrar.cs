using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Klaviyo.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Klaviyo.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class KlaviyoOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="KlaviyoOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddKlaviyoOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IKlaviyoOpenApiHttpClient, KlaviyoOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="KlaviyoOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddKlaviyoOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IKlaviyoOpenApiHttpClient, KlaviyoOpenApiHttpClient>();

        return services;
    }
}
