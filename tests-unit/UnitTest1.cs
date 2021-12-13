using NUnit.Framework;
using framework_core;
using System.IO;
using framework_core.Logging;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace tests_unit
{
    public class Tests
    {
        public ConfigurationService Config;

        [OneTimeSetUp]
        public void SetUp()
            {
            string file = "appSettings.json";
            Logger.Info("Full Path of Config File:"+Path.GetFullPath(file));
            this.Config = new ConfigurationService();
            this.Config.addJsonConfig(Path.GetFullPath(file));
            
            }
        [Test]
        public void ListSources()
            {
            var sourceList = this.Config.listSources();

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
                    Logger.Info($"{i} type: {env.GetType()} path: {env}");
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

        [Test]
        public void WhatIsIt()
        {
            this.Config.buildConfigSources();
            var allThese = this.Config.Root.GetChildren().GetEnumerator();
            while( allThese.MoveNext())
            {
                Logger.Info(allThese.Current.Key);

            }

            var timeSetting = this.Config.Root.GetSection("timeoutSettings").GetChildren().GetEnumerator();
            while (timeSetting.MoveNext())
            {
                Logger.Info($"{timeSetting.Current.Key}: {timeSetting.Current.Value}");

            }

        }
    }
}

