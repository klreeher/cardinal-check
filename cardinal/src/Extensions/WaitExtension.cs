using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace cardinal.webFramework
{
    /// <summary>
    /// Don't just wait until a specific time has passed, wait until a specific condition is fulfilled. Or you time out.
    /// </summary>
    public static class WaitExtension
    {
        /// <summary>
        /// Wait until the component Exists.
        /// </summary>
        /// <typeparam name="TComponent">the component object.</typeparam>
        /// <param name="component">this component.</param>
        /// <returns>returns the component, and it absolutely exists.</returns>
        public static TComponent ToExist<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToExistTimeout;
            WebDriverWait wait = new(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementExists(component.SourceLocator)));
            return component;
        }

        /// <summary>
        /// Sometimes an element exists but isn't visible on the page. Now you can wait until the element is visible.
        /// </summary>
        /// <typeparam name="TComponent">the type of component object.</typeparam>
        /// <param name="component">this component.</param>
        /// <returns>the component object, when it's visible on the page.</returns>
        public static TComponent ToBeVisible<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToBeVisibleTimeout;
            WebDriverWait wait = new(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementIsVisible(component.SourceLocator)));
            return component;
        }

        /// <summary>
        /// Sometimes things aren't clickable. Wait until the thing is clickable.
        /// </summary>
        /// <typeparam name="TComponent">the type of component object.</typeparam>
        /// <param name="component">this component.</param>
        /// <returns>the component object, when it's clickable on the page.</returns>
        public static TComponent ToBeClickable<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToBeClickableTimeout;
            WebDriverWait wait = new(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementToBeClickable(component.SourceLocator)));
            return component;
        }
    }
}