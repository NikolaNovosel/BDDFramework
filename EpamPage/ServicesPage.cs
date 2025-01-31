using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Serilog;

namespace EpamPage
{
    /// <summary>
    /// Represents the Services page of the application
    /// This class contains elements and actions related to the Services page
    /// </summary>
    public class ServicesPage : Page
    {
        public ServicesPage(IWebDriver driver) : base(driver) { }

        // Services link in the navigation menu
        private IWebElement Services => NavBar.FindElement(By.XPath("./li[1]"));

        // Button to open the dropdown menu
        private IWebElement ButtonNav => Driver.FindElement(By.XPath("//button[@class='hamburger-menu__button']"));

        // Services dropdown item within the dropdown menu
        private IWebElement ServicesDrop => Wait.Until(driver => 
        { 
            var element = Driver.FindElement(By.XPath("//div[@class='os-padding']/div[1]/div[1]/li[1]"));
            return element.Displayed && element.Enabled ? element : null;
        });

        // Artifical intelligence dropdown item within the Services dropdown.
        private IWebElement AiServicesDrop => Wait.Until(driver=> 
        { 
            var element = ServicesDrop.FindElement(By.XPath("./ul/li[5]")); 
            return element.Displayed && element.Enabled ? element : null;
        });

        // Parent element containing the page title
        private IWebElement ParentPageTitle => Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[2]"));

        // The main page title element
        private IWebElement PageTitle => ParentPageTitle.FindElement
        (By.XPath("//div[@class='colctrl__holder']//span[@class='museo-sans-500 gradient-text']"));

        // The section title within the main content area
        private IWebElement SectionTitle => Driver.FindElement
        (By.XPath("//main[@id='main']/div[1]//div[@class='text']//span[@class='museo-sans-light' and contains(text(), 'Our Related Expertise')]"));

        // Clicks on the Services link in the main navigation bar
        public void ClickServices()
        {
            Log.Information("Clicks on the Services link");
            Services.Click();
        }
        // Clicks on the button to open the dropdown menu
        public void ClickButtonNav()
        {
            Log.Information("Clicks on the button to open the droprown menu");
            ButtonNav.Click();

            Log.Information("Wait for the Services dropdown item to be displayed and enabled");
            Wait.Until(driver => ServicesDrop);
        }

        // Clicks on the Services dropdown item within the dropdown menu.
        public void ClickServicesDrop()
        {
            try
            {
                Log.Information("Clicked the Services dropdown item");
                ServicesDrop.Click();

                Log.Information("Wait for Artificial intelligence dropdown item be displayed and enabled");
                Wait.Until(driver => AiServicesDrop);
            }

            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Displayed && Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Clicked the Services dropdown");
                ServicesDrop.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Clicks on the Artificial intelligence dropdown item within the Services dropdown.
        public void ClickAiServicesDrop(string service)
        {
            Log.Information("Services dropdown item clicked");

            try
            {
                Log.Information("Clicks on the Artificial intelligence dropdown item");
                AiServicesDrop.Click();

                Log.Information("Wait for the selected item to be displayed and enabled");
                Wait.Until(driver => 
                AiServicesDrop.FindElement(By.PartialLinkText(service)).Displayed &&
                AiServicesDrop.FindElement(By.PartialLinkText(service)).Enabled);
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Displayed && Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Clicks on the Artificial intelligence dropdown item");
                AiServicesDrop.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Selects a specific service from the available options
        public void SelectService(string service)
        {
            Log.Information("Artificial intelligence dropdown item clicked");

            var selected = Wait.Until(driver =>
            {
                var element = AiServicesDrop.FindElement(By.PartialLinkText(service));
                return element.Displayed && element.Enabled ? element : null;
            });

            try
            {
                Log.Information("Try to select a specific service from the available options");
                selected.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Displayed && Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Try selects a specific service from the available options");
                selected.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Get the main page title text
        public string GetPageTitle() => PageTitle.Text;

        // Get the section title text
        public string GetSectionTitle() => SectionTitle.Text;
    }
}
