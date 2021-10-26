using OpenQA.Selenium;


namespace cardinal.webFramework
{
    /// <summary>
    /// Button Button, where is the [Button](https://www.w3schools.com/tags/tag_button.asp).
    /// </summary>
    public class Button : WebComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="sourceLocator">Locate That Button.</param>
        /// <param name="sourceElement">Locate That Button in This Object.</param>
        public Button(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Gets the width of the Button.
        /// </summary>
        public int Width => this.SourceElement.Size.Width;

        /// <summary>
        /// Gets the Height of the Button.
        /// </summary>
        public int Height => this.SourceElement.Size.Height;

        /// <summary>
        /// Gets the text on the button.
        /// </summary>
        public string Text => this.SourceElement.Text;

        /// <summary>
        /// CLICK! THAT! BUTTON.
        /// </summary>
        public void Click() => this.SourceElement.Click();
    }
}