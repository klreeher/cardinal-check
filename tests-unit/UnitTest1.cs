using NUnit.Framework;
using framework_core;
using System.IO;
using framework_core.Logging;

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
            this.Config.listSources();
            }

        [Test]
        public void WhatIsIt()
        {
            this.Config.buildConfigSources();
            var allThese = this.Config.Root.GetChildren().GetEnumerator();
            while( allThese.MoveNext())
            {
               // Logger.Info(allThese.Current.Key);
            }

            var timeSetting = this.Config.Root.GetSection("timeoutSettings").GetChildren().GetEnumerator();
            while (timeSetting.MoveNext())
            {
                Logger.Info($"{timeSetting.Current.Key}: {timeSetting.Current.Value}");

            }

        }
    }
}

