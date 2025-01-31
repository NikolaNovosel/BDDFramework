using Microsoft.Extensions.Configuration;

namespace EpamPageTests.Support
{
    /// </summary>
    /// Class for reading the app config data for testing purposes
    /// </summary>
    internal static class ConfigReader
    {
        // Initialize a ConfigurationBuilder and add the specified JSON configuration file
        private static readonly IConfigurationBuilder _builder = new ConfigurationBuilder().AddJsonFile(Location.JsonAppSettings);

        // Build the configuration and assign it to the Configuration property
        internal static IConfiguration Config = _builder.Build();
    }
}
