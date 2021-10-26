using System.IO;
using Microsoft.Extensions.Configuration;

namespace cardinal.webFramework
{
    /// <summary>
    ///  An instance that provides access to json config values.
    /// </summary>
    public sealed class ConfigurationService
    {
        private static ConfigurationService instance;

        private ConfigurationService()
        {
            var builder = new ConfigurationBuilder().AddJson.AddJsonFile(path: GetConfigFile(), false, true);
            this.Root = builder.Build();
        }

        /// <summary>
        /// Gets a singular instance of access to config values.
        /// </summary>
        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the root object for the configuration file.
        /// </summary>
        public IConfigurationRoot Root { get; }

        private static string GetConfigFile()
        {
#if Debug
            return "FrameworkSettings.dev.json";
#endif
#if QA
            return "FrameworkSettings.qa.json";
#endif
#if PROD
            return "FrameworkSettings.prod.json";
#endif
            throw new FileNotFoundException(
                "No configuration file found for the currently configured build configuration.");
        }
    }
}