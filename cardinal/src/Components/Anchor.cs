using System;
using OpenQA.Selenium;

namespace cardinal.webFramework
{
    /// <summary>
    /// [Anchor](https://www.w3schools.com/tags/tag_a.asp).
    /// </summary>
    public class Anchor : WebComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anchor"/> class.
        /// </summary>
        public Anchor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Anchor"/> class.
        /// </summary>
        /// <param name="sourceLocator">Locate! That! Anchor.</param>
        public Anchor(By sourceLocator)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Actions that are done before a click is executed. Like logging or screenshots.
        /// </summary>
        public static event EventHandler<string> BeforeClick;

        /// <summary>
        /// Actions that are done after a click is executed. Like logging or screenshots.
        /// </summary>
        public static event EventHandler<string> AfterClick;

        /// <summary>
        /// Gets that HREF html [attribute](https://www.w3schools.com/tags/att_href.asp).
        /// </summary>
        public string Href => this.SourceElement.GetAttribute("href");

        /// <summary>
        /// Gets the Text frpm the element(https://www.w3schools.com/tags/att_href.asp).
        /// </summary>
        public string Text => this.SourceElement.Text;

        /// <summary>
        /// Add the before/after actions to the Browser CLICK.
        /// </summary>
        public void Click()
        {
            BeforeClick?.Invoke(this, this.SourceLocator.ToString());
            this.SourceElement.Click();
            AfterClick?.Invoke(this, this.SourceLocator.ToString());
        }

        /// <summary>
        /// When you want to verify that the target URL is the URL you expect for this Anchor.
        /// </summary>
        /// <param name="expectedHref">expected target URL.</param>
        public void ValidateHrefIs(string expectedHref) => ComponentHelper.WaitUntil(() => this.Href.Equals(expectedHref, StringComparison.Ordinal));
    }
}