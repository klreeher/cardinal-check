
namespace cardinal.webFramework
{
    /// <summary>
    /// Lots of things have a SRC attribute.
    /// </summary>
    public interface ISrc
    {
        /// <summary>
        /// Gets that SRC attribute.
        /// </summary>
        string Src { get; }

        /// <summary>
        /// Is that SRC URL the URL you expect.
        /// </summary>
        /// <param name="expectedSrc">Expected URL.</param>
        public void ValidateSrc(string expectedSrc) => ComponentHelper.WaitUntil(() => this.Src.Equals(expectedSrc, System.StringComparison.Ordinal));
    }
}