using OpenQA.Selenium;
using Serilog;

namespace EpamPageTests.Support
{
    /// <summary>
    /// Utility class for logging and screenshot functionality in test automation.
    /// </summary>
    internal class HooksUtils
    {
        // Private field to store the WebDriver instance
        private readonly IWebDriver _driver;

        // Constructor to initialize the WebDriver instance
        internal HooksUtils(IWebDriver driver)
        {
            _driver = driver;
        }

        // Static method to configure and initialize the logger
        internal static void GetLog()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(Location.Log, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        // Static method to generate a file path for screenshots
        internal static string GetScreenShotPath() => Path.Combine(Location.ScreenShot, "screenshot", $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");

        // Method to take a screenshot and save it to the specified path
        internal HooksUtils TakeScreenShot()
        {
            var screenshot = ((ITakesScreenshot)_driver!).GetScreenshot();
            screenshot.SaveAsFile(GetScreenShotPath());

            return this;
        }
    }
}
