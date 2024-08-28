using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleOptions.Configuration;

/// <summary>
/// Provides extension methods for configuring options in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures the specified options type using the application's services and configuration.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to configure, which must implement <see cref="IConfigurationOptions"/>.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance used to configure the options.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance, allowing for method chaining.</returns>
    public static IServiceCollection ConfigureOption<TOptions>(this IServiceCollection services, IConfiguration configuration)
        where TOptions : class, IConfigurationOptions
    {
        ConfigurationHelper.Configure<TOptions>(services, configuration);
        return services;
    }
    
    /// <summary>
    /// Configures the specified options type and retrieves an instance of the configured options.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to configure, which must implement <see cref="IConfigurationOptions"/>.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance used to configure the options.</param>
    /// <param name="option">An output parameter that will contain the configured options instance.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance, allowing for method chaining.</returns>
    public static IServiceCollection ConfigureOption<TOptions>(this IServiceCollection services, IConfiguration configuration, out TOptions option)
        where TOptions : class, IConfigurationOptions
    {
        option = ConfigurationHelper.ConfigureAndGet<TOptions>(services, configuration);
        return services;
    }
}
