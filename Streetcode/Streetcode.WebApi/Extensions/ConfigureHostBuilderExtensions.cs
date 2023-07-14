﻿using AspNetCoreRateLimit;
using Streetcode.BLL.Services.BlobStorageService;
using Streetcode.BLL.Services.Instagram;
using Streetcode.BLL.Services.Payment;

namespace Streetcode.WebApi.Extensions;

public static class ConfigureHostBuilderExtensions
{
    public static void ConfigureApplication(this ConfigureHostBuilder host)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local";

        host.ConfigureAppConfiguration((_, config) =>
        {
            config.ConfigureCustom(environment);
        });
    }

    public static void ConfigureBlob(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<BlobEnvironmentVariables>(builder.Configuration.GetSection("Blob"));
    }

    public static void ConfigurePayment(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<PaymentEnvirovmentVariables>(builder.Configuration.GetSection("Payment"));
    }

    public static void ConfigureInstagram(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<InstagramEnvirovmentVariables>(builder.Configuration.GetSection("Instagram"));
    }

    public static void ConfigureRateLimiting(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddMemoryCache();
        services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        services.AddInMemoryRateLimiting();
    }
}