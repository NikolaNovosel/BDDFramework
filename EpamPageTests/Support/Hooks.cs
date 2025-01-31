using BoDi;
using EpamPageTests.Drivers;
using OpenQA.Selenium;
using Serilog;

namespace EpamPageTests.Support
{
    // Binding class for defining SpecFlow hooks to manage test setup and teardown
    [Binding]
    public sealed class Hooks
    {
        // Dependency injection container to manage object instances
        private readonly IObjectContainer _objectContainer;

        // WebDriver instance to interact with the browser
        private IWebDriver? _driver;

        // ScenarioContext to access scenario-specific data and results
        private readonly ScenarioContext? _scenarioContext;

        // Constructor to initialize dependencies
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        // Hook to execute before the entire test run
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Initialize logging for the test run
            HooksUtils.GetLog();
        }

        // Hook to execute before each scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize the WebDriver instance, Configure browser window settings and Navigate to the base URL
            _driver = DriverSingleton.GetDriver();
            DriverSingleton.ManageWindow();
            DriverSingleton.GetUrl();

            // Register the WebDriver instance in the dependency container
            _objectContainer?.RegisterInstanceAs(_driver);
        }

        // Hook to execute after each scenario
        [AfterScenario]
        public void AfterScenario()
        {
            // Check if the scenario failed
            if (_scenarioContext?.TestError != null)
            {
                // Log the failure details
                Log.Error("Scenario failed: {ScenarioTitle}", _scenarioContext.ScenarioInfo.Title);
                Log.Error("Error message: {ErrorMessage}", _scenarioContext.TestError.Message);

                // Take a screenshot of the failure
                new HooksUtils(_driver!).TakeScreenShot();

                // Log the screenshot file path
                Log.Information("Screenshot saved to {screenshotPath}", HooksUtils.GetScreenShotPath());
            }
            else
            {
                // Log the scenario success
                Log.Information("Scenario passed: {ScenarioTitle}", _scenarioContext?.ScenarioInfo.Title);
            }

            // Dispose of the WebDriver instance
            DriverSingleton.Dispose();
        }

        // Hook to execute after the entire test run
        [AfterTestRun]
        public static void AfterTestRun()
        {

            // Close and flush the logging system
            Log.CloseAndFlush();
        }
    }
}