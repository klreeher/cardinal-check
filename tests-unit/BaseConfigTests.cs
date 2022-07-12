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
    /// Tests for the Config **without** adding any additional sources.
    /// </summary>
    public class BaseConfigTests : BaseTestClass
    {
        /// <summary>
        /// With default, out of the box config, there is one source.
        /// </summary>
        [Test]
        public void CountSources()
        {
            var sourceList = this.Config.listSources();
            Assert.IsTrue(sourceList.Count == 1, "expected number of sources is 1.");

        }

        /// <summary>
        /// Unit Test to show that configuration object has children
        /// </summary>
        [Test]
        public void WhatSources()
        {
            this.Config.buildConfigSources();
            var allThese = this.Config.Root.GetChildren().GetEnumerator();
            while (allThese.MoveNext())
            {
                Assert.IsNotEmpty(allThese.Current.Key);
               // Logger.Info(allThese.Current.Key);
            }

            var timeoutSettings = this.Config.Root.GetSection("timeoutSettings").GetChildren();
            Assert.IsEmpty(timeoutSettings);

            var osSetting = this.Config.Root.GetSection("OS").Value;
            Logger.Info($"OS System Var is: {osSetting}");
            Assert.IsNotEmpty(osSetting);
        }
    }
}

