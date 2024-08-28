using Microsoft.Extensions.Hosting;

namespace SimpleOptions.Configuration;

/// <summary>
/// Provides extension methods for configuring options in an <see cref="IHostApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the specified options type using the application's services and configuration.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to configure, which must implement <see cref="IConfigurationOptions"/>.</typeparam>
    /// <param name="builder">The <see cref="IHostApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="IHostApplicationBuilder"/> instance, allowing for method chaining.</returns>
    public static IHostApplicationBuilder ConfigureOption<TOptions>(this IHostApplicationBuilder builder)
        where TOptions : class, IConfigurationOptions
    {
        ConfigurationHelper.Configure<TOptions>(builder.Services, builder.Configuration);
        return builder;
    }
    
    /// <summary>
    /// Configures the specified options type and retrieves an instance of the configured options.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to configure, which must implement <see cref="IConfigurationOptions"/>.</typeparam>
    /// <param name="builder">The <see cref="IHostApplicationBuilder"/> instance.</param>
    /// <param name="option">An output parameter that will contain the configured options instance.</param>
    /// <returns>The <see cref="IHostApplicationBuilder"/> instance, allowing for method chaining.</returns>
    public static IHostApplicationBuilder ConfigureOption<TOptions>(this IHostApplicationBuilder builder, out TOptions option)
        where TOptions : class, IConfigurationOptions
    {
        option = ConfigurationHelper.ConfigureAndGet<TOptions>(builder.Services, builder.Configuration);
        return builder;
    }
}
