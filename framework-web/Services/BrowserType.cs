namespace framework_web.Services
{
    
    /// <summary>
    /// Limited enum of supported browser types.
    /// </summary>
    public enum BrowserType
    {
        /// <summary>
        /// The BrowserType isn't requested or isn't set.
        /// </summary>
        NotSet,

        /// <summary>
        /// Chrome.
        /// </summary>
        Chrome,

        /// <summary>
        /// Microsoft Edge.
        /// </summary>
        Edge,

        /// <summary>
        /// Mozilla Firefox.
        /// </summary>
        Firefox,

        /// <summary>
        /// Safari. Better be on a Mac, Safari is no longer supported on Windows OS.
        /// </summary>
        Safari,
    }

}