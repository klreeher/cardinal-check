using Microsoft.Extensions.Configuration;

namespace cardinal.webFramework
{
    /// <summary>
    /// Controls configuration of the Web Settings.
    /// </summary>
    public static class WebSettingsConfigurationExtensions
    {
        /// <summary>
        /// Returns the various configuration values for Web/Browser based tests.
        /// </summary>
        /// <returns>WebSettings.</returns>
        /// <param name="configurationService">ConfigurationService.</param>
        public static WebSettings GetWebSettings(this ConfigurationService configurationService) => configurationService.Root.GetSection("webSettings").Get<WebSettings>();
    }
}