using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework_web.Services
{
    /// <summary>
    /// What Can You Do With A Web Browser.
    /// </summary>
    public class BrowserService
    {
        /// <summary>
        /// Gets the HTML page title for the browser at this point in time.
        /// </summary>
        public static string Title => DriverService.WrappedDriver.Value.Title;

        /// <summary>
        /// Browser driver page back.
        /// </summary>
        public static void Back() => DriverService.WrappedDriver.Value.Navigate().Back();

        /// <summary>
        /// Browser driver page forward.
        /// </summary>
        public static void Forward() => DriverService.WrappedDriver.Value.Navigate().Forward();

        /// <summary>
        /// Driver page refresh.
        /// </summary>
        public static void Refresh() => DriverService.WrappedDriver.Value.Navigate().Refresh();
    }
}

