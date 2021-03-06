using NUnit.Framework;
using framework_core;
using System.IO;
using framework_core.Logging;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace UnitTests
{
    /// <summary>
    /// Tests for the Config **with** additional sources added..
    /// </summary>
    public class ConfigTests : BaseTestClass
    {
        /// <summary>
        /// Initializes configuration with a json setting file.
        /// </summary>
        [SetUp]
        public void InitConfig()
        {
                string file = @".\appSettings01.json";
                Logger.Info(System.IO.Directory.GetCurrentDirectory());
                Logger.Info("Full Path of Config File:" + Path.GetFullPath(file));
                this.Config = new ConfigurationService();
                this.Config.addJsonConfig(Path.GetFullPath(file));
        }
        /// <summary>
        /// Make sure the Config actually gets the new souce.
        /// </summary>
        [Test]
        public void ListSources()
            {
            var sourceList = this.Config.listSources();
            Assert.IsTrue(sourceList.Count == 2, "expected number of sources is 1.");

            int i = 0;
            while (i <= sourceList.Count - 1)
            {
                if (sourceList[i].GetType().Name == "JsonConfigurationSource")
                {
                    JsonConfigurationSource test = (JsonConfigurationSource)sourceList[i];
                    Logger.Info($"{i} type: {test.GetType()} path: {test.Path}");
                }
                else if (sourceList[i].GetType().Name == "EnvironmentVariablesConfigurationSource")
                {
                    EnvironmentVariablesConfigurationSource env = (EnvironmentVariablesConfigurationSource)sourceList[i];
                    Logger.Info($"{i} type: {env.GetType()}");
                }
                else if (sourceList[i].GetType().Name == "CommandLineConfigurationExtensions")
                {
                    CommandLineConfigurationSource cmd = (CommandLineConfigurationSource)sourceList[i];
                    Logger.Info($"{i} type: {cmd.GetType()} path: {cmd.Args}");
                }
                else
                {
                    Logger.Info($"{i} type: {sourceList[i].GetType().Name}");
                }

                i++;
            }
        }
        /// <summary>
        /// Check different settings values from the config.
        /// </summary>
        [Test]
        public void WhatIsIt()
        {
            this.Config.buildConfigSources();
            var allThese = this.Config.Root.GetChildren().GetEnumerator();
            while( allThese.MoveNext())
            {
                Logger.Info(allThese.Current.Key);

            }

            var timeout = this.Config.Root.GetSection("timeoutSettings").GetChildren();
            Assert.IsNotEmpty(timeout);

            var timeSetting = this.Config.Root.GetSection("timeoutSettings").GetChildren().GetEnumerator();
            while (timeSetting.MoveNext())
            {
                Logger.Info($"{timeSetting.Current.Key}: {timeSetting.Current.Value}");

            }

        }
    }
}

