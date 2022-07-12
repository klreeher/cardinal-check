using System.Collections.Generic;
using System.IO;
using framework_core.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

namespace framework_core
    {
    /// <summary>
    ///  An instance that provides access to json config values.
    /// </summary>
    public sealed class ConfigurationService
        {
        private static ConfigurationService instance;
        /// <summary>
        /// 
        /// </summary>
        private ConfigurationBuilder _builder;
        /// <summary>
        /// Gets the root object for the configuration file.
        /// </summary>
        public IConfigurationRoot Root { get; set; }



        /// <summary>
        /// adds environment variables by default
        /// </summary>
        public ConfigurationService()
            {
            this._builder = new ConfigurationBuilder();
            this._builder.AddEnvironmentVariables();
            }
        public void buildConfigSources()
        {
            this.Root = this._builder.Build();
        }

        public string getSection(string sectionName)
        {
            return this.Root.GetSection(sectionName).Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public void addJsonConfig(string filePath) => this._builder.AddJsonFile(path: filePath, false, true);
        /// <summary>
        /// 
        /// </summary>
        public IList<IConfigurationSource> listSources()
            {
            return this._builder.Sources;
            }

        /// <summary>
        /// Gets a singular instance of access to config values.
        /// instantiates the ConfigurationService with a configuration builder with only env var.
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
        }
    }