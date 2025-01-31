using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using EpamPageTests.Support;

namespace EpamPageTests.Drivers
{
    /// <summary>
    /// Singleton class for managing WebDriver instances.
    /// </summary>
    internal class DriverSingleton
    {
        // Static WebDriver instance shared across the application
        private static IWebDriver? _driver;

        // Private constructor to prevent instantiation
        private DriverSingleton() { }

        // Returns a WebDriver instance for the specified browser (default: Chrome)
        internal static IWebDriver GetDriver(string browser = "firefox")
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver(DriverOption.GetChromeOptions());
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver(DriverOption.GetFirefoxOptions());
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    _driver = new EdgeDriver(DriverOption.GetEdgeOptions());
                    break;
                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported.");
            }

            return _driver;
        }

        // Disposes the WebDriver instance
        internal static void Dispose()
        {
            _driver?.Dispose();
        }

        // Manage the WebDriver window
        internal static void ManageWindow()
        {
            _driver?.Manage().Window.Maximize();
        }

        // Set the WebDriver Url
        internal static void GetUrl()
        {
            _driver!.Url = ConfigReader.Config["url"];
        }
    }
}
