using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using DriverService = cardinal.webFramework.DriverService;

namespace cardinal.webFramework
{
    /// <summary>
    /// Sometimes you want to take a screenshot.
    /// </summary>
    public static class ScreenshotEngine
    {

        // this should be the test runner (like nunit) 's test context

        /// <summary>
        /// Where should I save a screenshot if I should save a screenshot.
        /// This is a configuration value.
        /// </summary>
        public static void SaveScreenshot()
        {
            try
            {
                if (!ConfigurationService.Instance.GetWebSettings().ScreenshotsOnFailure)
                {
                    return;
                }

                string rootLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string saveLocation = Path.Combine(
                    rootLocation,
                    ConfigurationService.Instance.GetWebSettings().DefaultSaveLocation);
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }

                string fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMddTHHmmss}.png";
                string absoluteFilePath = Path.Combine(saveLocation, fileName);
                var image = ((ITakesScreenshot)DriverService.WrappedDriver.Value).GetScreenshot();
                image.SaveAsFile(absoluteFilePath);
                Logger.Error($"Saved Screenshot of Failure at {absoluteFilePath}");
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString());
                throw;
            }
        }
    }
}