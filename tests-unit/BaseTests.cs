using NUnit.Framework;
using framework_core;
using System.IO;
using framework_core.Logging;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace tests_unit
{
    /// <inheritdoc></inheritdoc>
    public class BaseTests : BaseTestClass
    {
        [Test]
        public void CountSources()
            {
            var sourceList = this.Config.listSources();
            Assert.IsTrue(sourceList.Count == 1, "expected number of sources is 1.");
            
        }

        [Test]
        public void WhatSources()
        {
            this.Config.buildConfigSources();
            var allThese = this.Config.Root.GetChildren().GetEnumerator();
            while( allThese.MoveNext())
            {
                Logger.Info(allThese.Current.Key);

            }

            var timeoutSettings = this.Config.Root.GetSection("timeoutSettings").GetChildren();

            Assert.IsEmpty(timeoutSettings);
            }

        }
    }

