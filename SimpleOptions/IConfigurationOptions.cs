namespace SimpleOptions;

/// <summary>
/// Base interface for configuration options.
/// </summary>
public interface IConfigurationOptions
{
    /// <summary>
    /// Name of the configuration section.
    /// </summary>
    static abstract string SectionName { get; }
}

/// <summary>
/// Base class for configuration options that retrieves the section name based on the derived type.
/// </summary>
/// <typeparam name="TOptions">The type of the derived configuration options class.</typeparam>
public abstract class ConfigurationOptions<TOptions> : IConfigurationOptions
    where TOptions : ConfigurationOptions<TOptions>
{
    /// <inheritdoc/>
    public static string SectionName => typeof(TOptions).Name;
}