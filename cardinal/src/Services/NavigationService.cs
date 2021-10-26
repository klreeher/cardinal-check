using System;

namespace cardinal.webFramework
{
    /// <summary>
    /// Sometimes, you want to do something special and complicated when you travel around the World Wide Web.
    /// </summary>
    public class NavigationService
    {
        /// <summary>
        /// Event that happens BEFORE the browser navigates to the target.
        /// </summary>
        public static event EventHandler<string> BeforeGoTo;

        /// <summary>
        /// Event that happens AFTER the browser navigates to the target.
        /// </summary>
        public static event EventHandler<string> AfterGoTo;

        /// <summary>
        /// Take that browser to open the provided URL.
        /// </summary>
        /// <param name="url">Where do you want to go.</param>
        public void GoTo(string url)
        {
            BeforeGoTo?.Invoke(this, url);
            DriverService.WrappedDriver.Value.Navigate().GoToUrl(url);
            AfterGoTo?.Invoke(this, url);
        }
    }
}