using EpamPage;
using OpenQA.Selenium;

namespace EpamPageTests.StepDefinitions
{
    // Binding class for defining SpecFlow steps related to the Careers page
    [Binding]
    public class CareersPageStep
    {
        // Private field to hold an instance of the CareersPage class for interacting with the Careers page
        private readonly CareersPage _careersPage;

        // Constructor to initialize the CareersPage object with the WebDriver instance
        public CareersPageStep(IWebDriver driver)
        {
            _careersPage = new(driver);
        }

        // Step definition for clicking the "Careers" option from the top menu
        [Given(@"I click Careers from the top menu")]
        public void GivenIClickCareersFromTheTopMenu()
        {
            _careersPage.ClickCareers();
        }

        // Step definition for entering a keyword in the Keyword field
        [When(@"I enter the keyword ""([^""]*)"" in the Keyword field")]
        public void WhenIEnterTheKeywordInTheKeywordField(string keyword)
        {
            _careersPage.SendKeysKeyword(keyword);
        }

        // Step definition for selecting "All locations" from the Location dropdown
        [When(@"I select All locations from the Location dropdown")]
        public void WhenISelectAllLocationsFromTheLocationDropdown()
        {
            _careersPage.ClickLocation();
            _careersPage.ClickAllLocations();
        }

        // Step definition for selecting the Remote option
        [When(@"I select the Remote option")]
        public void WhenISelectTheRemoteOption()
        {
            _careersPage.ClickRemote();
        }

        // Step definition for clicking the Find button
        [When(@"I click the Find button")]
        public void WhenIClickTheFindButton()
        {
            _careersPage.ClickFindCareers();
        }

        // Step definition for clicking the "View and apply" button of the latest result
        [When(@"I click on the View and apply button of the latest result")]
        public void WhenIClickOnTheViewAndApplyButtonOfTheLatestResult()
        {
            _careersPage.ClickViewAndApply();
        }

        // Step definition to validate if the job description contains the specified keyword
        [Then(@"Job description should contains the keyword ""([^""]*)""")]
        public void ThenJobDescriptionShouldContainsTheKeyword(string keyword)
        {
            _careersPage.GetCareersArticleText().Should().Contain(keyword);
        }
    }
}
