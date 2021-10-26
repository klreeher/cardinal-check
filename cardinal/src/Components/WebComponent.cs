using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using DriverService = cardinal.webFramework.DriverService;

namespace cardinal.webFramework
{
    /// <summary>
    /// Represents the various HTML and CSS objects on a webpage.
    /// </summary>
    public class WebComponent
    {
        private readonly List<Action> waitActions = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebComponent"/> class.
        /// Base class for Web Components.
        /// </summary>
        public WebComponent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebComponent"/> class based on a By sourceLocator.
        /// </summary>
        /// <param name="sourceLocator">the By locator used to identify the specific component.</param>
        public WebComponent(By sourceLocator)
        {
            this.SourceLocator = sourceLocator;
        }

        /// <summary>
        /// Gets or sets the parent element for the specified component.
        /// </summary>
        public IWebElement ParentElement { get; set; }

        /// <summary>
        /// Gets a value indicating whether the element is Displayed.
        /// </summary>
        public bool IsVisible => this.SourceElement.Displayed;

        /// <summary>
        /// Gets or sets the Source [attribute](https://www.w3schools.com/tags/att_src.asp) on the Component.
        /// </summary>
        public By SourceLocator { get; set; }

        /// <summary>
        /// Gets the Source [attribute](https://www.w3schools.com/tags/att_src.asp) on the Component.
        /// </summary>
        public IWebElement SourceElement
        {
            get
            {
                if (!this.waitActions.Any())
                {
                    this.ToExist();
                }

                foreach (var act in this.waitActions)
                {
                    act.Invoke();
                }

                return this.ParentElement != null
                    ? this.ParentElement.FindElement(this.SourceLocator)
                    : DriverService.WrappedDriver.Value.FindElement(this.SourceLocator);
            }
        }

        /// <summary>
        /// Creates a new Component.
        /// </summary>
        /// <typeparam name="TComponent">TComponent Type.</typeparam>
        /// <param name="locator">Takes a locator.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent Create<TComponent>(By locator)
            where TComponent : WebComponent
        {
            var newComponent = Activator.CreateInstance<TComponent>();
            newComponent.SourceLocator = locator;
            newComponent.ParentElement = this.SourceElement;

            return newComponent;
        }

        /// <summary>
        /// Creates a new Component by the ID tag alone.
        /// </summary>
        /// <typeparam name="TComponent">TComponent type.</typeparam>
        /// <param name="id">string of the id tag.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateById<TComponent>(string id)
            where TComponent : WebComponent => this.Create<TComponent>(By.Id(id));

        /// <summary>
        /// Creates a new Component by the xpath alone.
        /// </summary>
        /// <typeparam name="TComponent">TComponent type.</typeparam>
        /// <param name="xpath">string of xpath expression.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateByXpath<TComponent>(string xpath)
            where TComponent : WebComponent => this.Create<TComponent>(By.XPath(xpath));

        /// <summary>
        /// Creates a new Component by the css tag alone.
        /// </summary>
        /// <typeparam name="TComponent">tcomponent type.</typeparam>
        /// <param name="tag">string of the tag.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateByTag<TComponent>(string tag)
            where TComponent : WebComponent => this.Create<TComponent>(By.TagName(tag));

        /// <summary>
        /// Creates a new Component by the css class alone.
        /// </summary>
        /// <typeparam name="TComponent">tcomponent type.</typeparam>
        /// <param name="className">string of the class.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateByClass<TComponent>(string className)
            where TComponent : WebComponent => this.Create<TComponent>(By.ClassName(className));

        /// <summary>
        /// Creates a new Component by the text in the class name alone.
        /// </summary>
        /// <typeparam name="TComponent">tcomponent type.</typeparam>
        /// <param name="classText">substring of the class string.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateByClassContains<TComponent>(string classText)
            where TComponent : WebComponent => this.CreateByXpath<TComponent>($"//*[contains(@class, '{classText}')]");

        /// <summary>
        /// Returns a new component created by an id containing the input value.
        /// found using an xpath.
        /// </summary>
        /// <typeparam name="TComponent">tcomponent type.</typeparam>
        /// <param name="id">partial text for the id.</param>
        /// <returns>Returns a strongly typed component object.</returns>
        public TComponent CreateByIdContains<TComponent>(string id)
            where TComponent : WebComponent => this.CreateByXpath<TComponent>($"//*[contains(@id, '{id}')]");

        /// <summary>
        /// Add a custom thing to wait for for this element.
        /// </summary>
        /// <param name="action">custom action to wait for.</param>
        public void AddWaitAction(Action action) => this.waitActions.Add(action);
    }
}