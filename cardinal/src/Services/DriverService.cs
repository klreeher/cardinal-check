using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace cardinal.webFramework
{
    /// <summary>
    /// The DriverService makes the various web browser driver functionality availble.
    /// </summary>
    public class DriverService
    {
        static DriverService()
        {
            WrappedDriver = new ThreadLocal<IWebDriver>();
#pragma warning disable SA1500 // Braces for multi-line statements should not share line
            PreviousBrowserType = new ThreadLocal<BrowserType> {
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
                Value = BrowserType.NotSet,
            };
        }

        /// <summary>
        /// gets the thread-local driver. Allows different browsers to be spawned for different tests.
        /// </summary>
        public static ThreadLocal<IWebDriver> WrappedDriver { get; }

        /// <summary>
        /// gets the previously request browser type. If not set, returns NotSet.
        /// </summary>
        public static ThreadLocal<BrowserType> PreviousBrowserType { get; }

        /// <summary>
        /// Quit the web browser instance and verify that the process is fully disposed of.
        /// </summary>
        public static void Quit()
        {
            WrappedDriver.Value?.Quit();
            WrappedDriver.Value?.Dispose();
        }

        /// <summary>
        /// wraps the driver manage cookies.delete all cookies.
        /// </summary>
        public static void ClearCookies() => WrappedDriver.Value.Manage().Cookies.DeleteAllCookies();

        /// <summary>
        /// Gets the default browser type and starts a new instance thereof.
        /// </summary>
        public static void Start()
        {
#pragma warning disable IDE0007 // Use implicit type
#pragma warning disable IDE0008 // Use explicit type
            var browserName = ConfigurationService.Instance.GetWebSettings().DefaultBrowser;
#pragma warning restore IDE0008 // Use explicit type
            BrowserType defaultBrowser = ParseBrowserTypeFromString(browserName);
#pragma warning restore IDE0007 // Use implicit type
            Start(defaultBrowser);
        }

        /// <summary>
        /// Starts a new browser driver instance for the requested BrowserType.
        /// If Headless is set in the WebSettings to True, the browser driver will be started in headless mode.
        /// </summary>
        /// <param name="browserType">What is the requested BrowserType.</param>
        public static void Start(BrowserType browserType)
        {
            bool headless = ConfigurationService.Instance.GetWebSettings().HeadlessBrowser;

            IWebDriver driver = default;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    // chrome requires you to match the DRIVER version with the installed CHROME browser version. x.x
                    ChromeOptions optsC = new();

                    if (headless)
                    {
                        optsC.AddArgument("headless");
                    }

                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver(optsC);

                    break;
                case BrowserType.Edge:
                    EdgeOptions optsE = new();
                    if (headless)
                    {
                        optsE.AddArgument("headless");
                    }

                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver(optsE);
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions optsFF = new();
                    if (headless)
                    {
                        optsFF.AddArgument("headless");
                    }

                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(optsFF);
                    break;
                case BrowserType.Safari:
                    throw new NotImplementedException($"{nameof(browserType)} Not Supported");
                case BrowserType.NotSet:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(browserType),
                        browserType,
                        $"{nameof(browserType)} Not Supported");
            }

            PreviousBrowserType.Value = browserType;

            WrappedDriver.Value = driver;
            driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(ConfigurationService.Instance.GetTimeoutSettings().PageLoadTimeout);
            driver.Manage().Timeouts().AsynchronousJavaScript =
                TimeSpan.FromSeconds(ConfigurationService.Instance.GetTimeoutSettings().JavascriptTimeout);
        }

        private static BrowserType ParseBrowserTypeFromString(string browserName)
        {
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browserName, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}