namespace cardinal.webFramework
{
    /// <summary>
    /// Love some Configuration File settings around Timeouts.
    /// </summary>
    public class TimeoutSettings
    {
        /// <summary>
        /// Gets and sets initially the time to wait for an element to exist.
        /// </summary>
        public int ElementToExistTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for an element to not exist.
        /// </summary>
        public int ElementToNotExistTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for an element to be visible on the page.
        /// </summary>
        public int ElementToBeVisibleTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for an element to not be visible on the page.
        /// </summary>
        public int ElementNotToBeVisibleTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for an element to be available to click on the page.
        /// </summary>
        public int ElementToBeClickableTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for an element to have content on the page.
        /// </summary>
        public int ElementToHaveContentTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for the entire page to have content.
        /// </summary>
        public int PageLoadTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for javascript to load.
        /// </summary>
        public int JavascriptTimeout { get; init; }

        /// <summary>
        /// Gets and sets initially the time to wait for the validation process.
        /// </summary>
        public int ValidationTimeout { get; init; }
    }
}