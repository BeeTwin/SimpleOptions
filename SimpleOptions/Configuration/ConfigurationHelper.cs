using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleOptions.Configuration;

internal static class ConfigurationHelper
{
    public static void Configure<TOptions>(IServiceCollection services, IConfiguration configuration)
        where TOptions : class, IConfigurationOptions =>
        services.Configure<TOptions>(configuration.GetRequiredSection(TOptions.SectionName));

    public static TOptions ConfigureAndGet<TOptions>(IServiceCollection services, IConfiguration configuration)
        where TOptions : class, IConfigurationOptions
    {
        var optionSection = configuration.GetRequiredSection(TOptions.SectionName);
        var option = optionSection.Get<TOptions>();
        if (option is null)
            throw new InvalidOperationException($"Unable to create options of type {typeof(TOptions)}.");
        
        services.Configure<TOptions>(optionSection);
        return option;
    }
}