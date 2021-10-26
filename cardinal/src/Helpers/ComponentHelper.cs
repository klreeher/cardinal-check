using System;
using OpenQA.Selenium.Support.UI;

namespace cardinal.webFramework
{
    /// <summary>
    /// Sometimes it's handy to have helper fucntionality for Components specifically.
    /// </summary>
    public class ComponentHelper
    {
        /// <summary>
        /// Wait until the expected thing happens.
        /// </summary>
        /// <param name="condition">when do I stop waiting.</param>
        public static void WaitUntil(Func<bool> condition)
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ValidationTimeout;
            WebDriverWait wait = new(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            wait.Until(d => condition());
        }
    }
}