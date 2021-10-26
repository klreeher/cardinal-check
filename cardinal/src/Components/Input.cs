using System;
using OpenQA.Selenium;

namespace cardinal.webFramework
{
    /// <summary>
    /// Lots of things have Inputs.
    /// https://www.w3schools.com/tags/tag_input.asp.
    /// </summary>
    public class Input : WebComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        public Input()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="sourceLocator">Locate That Input.</param>
        public Input(By sourceLocator)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Sometimes you want to do something special Before you click on the input.
        /// </summary>
        public static event EventHandler<string> BeforeClick;

        /// <summary>
        /// Sometimes you want to do something special After you click on the input.
        /// </summary>
        public static event EventHandler<string> AfterClick;

        /// <summary>
        /// Gets that Input Name attribute.
        /// </summary>
        public string Name => this.SourceElement.GetAttribute("name");

        /// <summary>
        /// Gets the placeholder text.
        /// </summary>
        public string Placeholder => this.SourceElement.GetAttribute("placeholder");

        /// <summary>
        /// Gets that Type attribute for the Input.
        /// </summary>
        public string Type => this.SourceElement.GetAttribute("type");

        /// <summary>
        /// Click that input to put the INPUT in focus.
        /// </summary>
        public void Click()
        {
            BeforeClick?.Invoke(this, this.SourceLocator.ToString());
            this.SourceElement.Click();
            AfterClick?.Invoke(this, this.SourceLocator.ToString());
        }

        /// <summary>
        /// Sends Keys for inputs.
        /// </summary>
        /// <param name="text">Text to fill input with.</param>
        public void FillInput(string text) => this.SourceElement.SendKeys(text);

        /// <summary>
        /// Sends Keys for inputs.
        /// </summary>
        public void WaitForInput() => ComponentHelper.WaitUntil(() => this.SourceElement.Displayed);
    }
}