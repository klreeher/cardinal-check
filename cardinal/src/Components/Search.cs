using OpenQA.Selenium;

namespace cardinal.webFramework
{
    /// <summary>
    /// [input type="search"](https://www.w3schools.com/tags/tag_input.asp).
    /// </summary>
    public class Search : WebComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        public Search()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="sourceLocator">How do Locate the Source.</param>
        /// <param name="sourceElement">Gimme that source element object.</param>
        public Search(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Gets That Placeholder Text Attribute.
        /// </summary>
        public string PlaceholderText => this.SourceElement.GetAttribute("placeholder");

        /// <summary>
        /// Fill out that Search Input and hit enter.
        /// </summary>
        /// <param name="searchText">text to fill out input box.</param>
        public void SearchFor(string searchText)
        {
            this.SourceElement.Clear();
            this.SourceElement.SendKeys(searchText);
            this.SourceElement.SendKeys(Keys.Return);
        }
    }
}