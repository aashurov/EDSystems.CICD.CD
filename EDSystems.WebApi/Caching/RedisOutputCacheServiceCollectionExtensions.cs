using System;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EDSystems.WebApi.Caching;

/// <summary>
/// 
/// </summary>
public static class RedisOutputCacheServiceCollectionExtensions
{
    //public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
    //{
    //    ArgumentNullException.ThrowIfNull(services);
    //    services.AddOutputCache();
    //    services.RemoveAll<IOutputCacheStore>();
    //    services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();
    //    return services;
    //}

    //public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
    //{
    //    ArgumentNullException.ThrowIfNull(services);
    //    ArgumentNullException.ThrowIfNull(configureOptions);

    //    services.Configure(configureOptions);
    //    services.AddOutputCache();

    //    services.RemoveAll<IOutputCacheStore>();
    //    services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

    //    return services;
    //}

}

