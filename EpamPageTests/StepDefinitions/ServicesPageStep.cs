
using EpamPage;
using OpenQA.Selenium;

namespace EpamPageTests.StepDefinitions
{
    // Binding class for defining SpecFlow steps related to the Services page
    [Binding]
    public class ServicesPageStep
    {
        // Private field to hold an instance of the ServicesPage class
        private readonly ServicesPage _servicesPage;

        // Constructor to initialize the ServicesPage object with the WebDriver instance
        public ServicesPageStep(IWebDriver driver)
        {
            _servicesPage = new(driver);
        }

        // Step definition for clicking the "Services" link in the main navigation menu
        [Given(@"I click on the Services link in the main navigation menu")]
        public void GivenIClickOnTheServicesLinkInTheMainNavigationMenu()
        {
            _servicesPage.ClickServices();
        }

        // Step definition for selecting a specific service category from the dropdown menu
        [When(@"I select the service category ""([^""]*)""")]
        public void WhenISelectTheServiceCategory(string service)
        {
            _servicesPage.ClickButtonNav();
            _servicesPage.ClickServicesDrop();
            _servicesPage.ClickAiServicesDrop();
            _servicesPage.SelectService(service);
        }

        // Step definition to validate if the page title contains the selected service category
        [Then(@"The page title should contain ""([^""]*)""")]
        public void ThenThePageTitleShouldContain(string service)
        {
            _servicesPage.GetPageTitle().Should().Contain(service);
        }

        // Step definition to validate if the specified section is displayed on the page
        [Then(@"I should see the section ""([^""]*)"" displayed on the page")]
        public void ThenIShouldSeeTheSectionDisplayedOnThePage(string service)
        {
            _servicesPage.GetSectionTitle().Should().Contain(service);
        }
    }
}
