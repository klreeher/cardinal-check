using Microsoft.Extensions.Configuration;

namespace cardinal.webFramework
{
    /// <summary>
    /// Get those timeout configurations from the json config file.
    /// </summary>
    public static class TimeoutSettingsConfigurationExtensions
    {
        /// <summary>
        /// Returns the various timeout related settings and their values.
        /// </summary>
        /// <param name="configurationService">This configuration service instance.</param>
        /// <returns>The various Timeout Settings.</returns>
        public static TimeoutSettings GetTimeoutSettings(this ConfigurationService configurationService) => configurationService.Root.GetSection("timeoutSettings").Get<TimeoutSettings>();
    }
}