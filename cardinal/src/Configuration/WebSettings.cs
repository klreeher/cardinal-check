namespace cardinal.webFramework
{
    /// <summary>
    /// Returns the various configuration values for Web/Browser based tests.
    /// </summary>
    public class WebSettings
    {
        /// <summary>
        /// Gets the default browser for UI tests if none is specified.
        /// </summary>
        public string DefaultBrowser { get; init; }

        /// <summary>
        /// Gets the location for screenshots to be saved to, if ScreenshotsOnFailure is enabled.
        /// </summary>
        public string DefaultSaveLocation { get; init; }

        /// <summary>
        /// Gets a value indicating whether a screenshot should be taken at time of failure.
        /// </summary>
        public bool ScreenshotsOnFailure { get; init; }

        /// <summary>
        /// Gets a value indicating whether the BDD logging plugin is availble globally.
        /// </summary>
        public bool BddLogging { get; init; }

        /// <summary>
        /// Gets a value indicating whether the browser driver(s) are started with a headless option or not.
        /// </summary>
        public bool HeadlessBrowser { get; init; }
    }
}