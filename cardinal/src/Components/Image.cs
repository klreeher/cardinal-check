using OpenQA.Selenium;

namespace cardinal.webFramework
{
    /// <summary>
    /// Web pages can show images now, unless you're on Lynx.
    /// https://www.w3schools.com/tags/tag_img.asp.
    /// </summary>
    public class Image : WebComponent, ISrc
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="sourceLocator">Locate! That! IMG.</param>
        public Image(By sourceLocator)
            : base(sourceLocator)
        {
        }

        /// <summary>
        /// Gets the width of the image as displayed.
        /// </summary>
        public int Width => this.SourceElement.Size.Width;

        /// <summary>
        /// Gets the height of the image as displayed.
        /// </summary>
        public int Height => this.SourceElement.Size.Height;

        /// <summary>
        /// Gets the HREF of the IMAGE. Are you hotlinking.
        /// </summary>
        public string Href => this.SourceElement.GetAttribute("href");

        /// <summary>
        /// Gets the SRC of the IMAGE. Are you hotlinking.
        /// </summary>
        public string Src => this.SourceElement.GetAttribute("src");

        /// <summary>
        /// Is that SRC URL the URL you expect.
        /// </summary>
        /// <param name="expectedSrc">Expected URL.</param>
        public void ValidateSrc(string expectedSrc) => ComponentHelper.WaitUntil(condition: () => this.Src.Equals(expectedSrc, System.StringComparison.Ordinal));
    }
}