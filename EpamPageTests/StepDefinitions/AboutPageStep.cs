using EpamPage;
using EpamPageTests.Support;
using OpenQA.Selenium;

namespace EpamPageTests.StepDefinitions
{
    // Binding class for defining SpecFlow steps related to the About page
    [Binding]
    public class AboutPageStep
    {
        // Private field to hold an instance of the AboutPage class
        private readonly AboutPage _aboutPage;

        // Constructor to initialize the AboutPage object with the WebDriver instance
        public AboutPageStep(IWebDriver driver)
        {
            _aboutPage = new (driver);
        }

        // Step definition for clicking the "About" option from the top menu
        [Given(@"I click About from the top menu")]
        public void GivenIClickAboutFromTheTopMenu()
        {
            _aboutPage.ClickAbout();
        }

        // Step definition for scrolling down to the "EPAM at a Glance" section

        [When(@"I scroll down to the EPAM at a Glance section")]
        public void WhenIScrollDownToTheEPAMAtAGlanceSection()
        {
            _aboutPage.ScrollToEpamAtGlance(); ;
        }

        // Step definition for clicking the Download button
        [When(@"I click on the Download button")]
        public void WhenIClickOnTheDownloadButton()
        {
            _aboutPage.ClickDownload();
        }

        // Step definition to validate if the specified file is downloaded within five seconds
        [Then(@"I should have the file ""([^""]*)"" downloaded within five seconds")]
        public static void ThenIShouldHaveTheFileDownloadedWithinFiveSeconds(string fileName)
        {
            AboutPageValidation.WaitForFileDownload(fileName).Should().BeTrue();
        }
    }
}
