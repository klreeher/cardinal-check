using framework_core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework_web.Configuration
{
    /// <summary>
    /// Controls configuration of the Web Settings.
    /// </summary>
    public static class WebSettingsConfiguration
    {
        /// <summary>
        /// Returns the various configuration values for Web/Browser based tests.
        /// </summary>
        /// <returns>WebSettings.</returns>
        /// <param name="configurationService">ConfigurationService.</param>
        public static WebSettings GetWebSettings(this ConfigurationService configurationService) => configurationService.Root.GetSection("webSettings").Get<WebSettings>();
    }
}
