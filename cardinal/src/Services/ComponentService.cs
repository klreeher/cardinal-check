using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace cardinal.webFramework
{
    /// <summary>
    /// Lets Find Those Web Components.
    /// </summary>
    public class ComponentService
    {
        /// <summary>
        /// Creates a strongly typed component by exact id match.
        /// </summary>
        /// <typeparam name="TComponent">strongly-typed component.</typeparam>
        /// <param name="id">exact id string.</param>
        /// <returns>a strongly-typed component.</returns>
        public static TComponent CreateById<TComponent>(string id)
            where TComponent : WebComponent => Create<TComponent>(By.Id(id));

        /// <summary>
        /// Creates a strongly typed component by XPATH expression.
        /// </summary>
        /// <typeparam name="TComponent">strongly-typed component.</typeparam>
        /// <param name="xpath">xpath expression.</param>
        /// <returns>a strongly-typed component.</returns>
        public static TComponent CreateByXpath<TComponent>(string xpath)
            where TComponent : WebComponent => Create<TComponent>(By.XPath(xpath));

        /// <summary>
        /// Creates a strongly typed component by exact class text match.
        /// </summary>
        /// <typeparam name="TComponent">strongly typed component.</typeparam>
        /// <param name="className">exact text match for class.</param>
        /// <returns>strongly-typed component.</returns>
        public static TComponent CreateByClass<TComponent>(string className)
            where TComponent : WebComponent => Create<TComponent>(By.ClassName(className));

        /// <summary>
        /// Creates a strongly typed component by partial class text match.
        /// </summary>
        /// <typeparam name="TComponent">strongly typed component.</typeparam>
        /// <param name="classText">partial text match for class.</param>
        /// <returns>strongly-typed component.</returns>
        public static TComponent CreateByClassContains<TComponent>(string classText)
            where TComponent : WebComponent => CreateByXpath<TComponent>($"//*[contains(@class, '{classText}')]");

        /// <summary>
        /// Create a strongly typed component by partial id string match.
        /// </summary>
        /// <typeparam name="TComponent">strongly typed component.</typeparam>
        /// <param name="id">partial string for id.</param>
        /// <returns>strongly-typed component.</returns>
        public static TComponent CreateByIdContains<TComponent>(string id)
            where TComponent : WebComponent => CreateByXpath<TComponent>($"//*[contains(@id, '{id}')]");

        /// <summary>
        /// Create a strongly typed component object by By locator.
        /// </summary>
        /// <typeparam name="TComponent">what kind of component.</typeparam>
        /// <param name="locator">By locator object.</param>
        /// <returns>brand new strongly typed component.</returns>
        public static TComponent Create<TComponent>(By locator)
            where TComponent : WebComponent
        {
            var newComponent = Activator.CreateInstance<TComponent>();
            newComponent.SourceLocator = locator;

            return newComponent;
        }

        private static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator)
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToExistTimeout;
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(elementTimeout));
            var nativeWebElement =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            return nativeWebElement;
        }
    }
}