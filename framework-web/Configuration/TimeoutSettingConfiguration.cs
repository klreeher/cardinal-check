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