using System;
using OpenQA.Selenium;

namespace cardinal.webFramework
{
    /// <summary>
    /// Lots of things have spans.
    /// https://www.w3schools.com/tags/tag_span.asp.
    /// </summary>
    public class Span : WebComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Span"/> class.
        /// </summary>
        public Span()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Span"/> class.
        /// </summary>
        /// <param name="sourceLocator">Locate That span.</param>
        public Span(By sourceLocator)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Sometimes you want to do something special Before you click on the span.
        /// </summary>
        public static event EventHandler<string> BeforeClick;

        /// <summary>
        /// Sometimes you want to do something special After you click on the span.
        /// </summary>
        public static event EventHandler<string> AfterClick;

        /// <summary>
        /// Gets that span Name attribute.
        /// </summary>
        public string Name => this.SourceElement.GetAttribute("name");

        /// <summary>
        /// Gets the placeholder text.
        /// </summary>
        public string Placeholder => this.SourceElement.GetAttribute("placeholder");

        /// <summary>
        /// Gets that Type attribute for the span.
        /// </summary>
        public string Type => this.SourceElement.GetAttribute("type");

        /// <summary>
        /// Gets the text from the span.
        /// </summary>
        public string Text => this.SourceElement.Text;

        /// <summary>
        /// Sends Keys for inputs.
        /// </summary>
        public void WaitForInput() => ComponentHelper.WaitUntil(() => this.SourceElement.Displayed);
    }
}
