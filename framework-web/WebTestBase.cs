using framework_core;
using framework_web.Services;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace framework_web
{
    public class WebTestBase
    {
            private static readonly ThreadLocal<bool> ArePluginsSubscribed = new();

            /// <summary>
            /// Gets the Browser Service that this base test class uses.
            /// </summary>
            public static BrowserService Browser => new();

            /// <summary>
            /// Gets the Nav Services that this base test class uses.
            /// </summary>
            public static NavigationService Navigation => new();

            /// <summary>
            /// Gets the Component Services that this base test class uses.
            /// </summary>
           // public static ComponentService Component => new();

            /// <summary>
            /// Gets the Configuration Service that this Base Test class uses.
            /// </summary>
            public static ConfigurationService Configuration => ConfigurationService.Instance;

            /// <summary>
            ///  Runs before the tests in the class do. Sets up the Browser driver and Plugins.
            /// </summary>
            [SetUp]
            public void TestSetUp()
            {
                if (!ArePluginsSubscribed.Value)
                {
                    this.SetUpPlugins();
                    ArePluginsSubscribed.Value = true;
                }

                // this first check is if there are multiple tests running in sequence using multiple browsers
                object requestedBrowserObj = TestContext.CurrentContext.Test.Arguments.FirstOrDefault();
                if (requestedBrowserObj != null && requestedBrowserObj.GetType().Name.Equals("BrowserType", System.StringComparison.Ordinal))
                {
                    if (requestedBrowserObj.Equals(DriverService.PreviousBrowserType.Value))
                    {
                    }
                    else
                    {
                        DriverService.Quit();
                        DriverService.Start((BrowserType)requestedBrowserObj);
                    }
                }
                else
                {
                    DriverService.Quit();
                    DriverService.Start();
                }
            }

            /// <summary>
            /// At the end of the Test Case Execution, does anything special happen.
            /// </summary>
            [TearDown]
            public void TestTeardown()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
                {
                    //ScreenshotEngine.SaveScreenshot();
                    DriverService.Quit();
                    DriverService.Start();
                }

                DriverService.ClearCookies();
            }

            /// <summary>
            /// Take Down That Driver.
            /// </summary>
            [OneTimeTearDown]
            public void Teardown() => DriverService.Quit();

            /// <summary>
            /// This is where you enable plugins specifically for tests that inherit from the Web Test Case.
            /// </summary>
            protected virtual void SetUpPlugins()
            {
            }
        }
    }

