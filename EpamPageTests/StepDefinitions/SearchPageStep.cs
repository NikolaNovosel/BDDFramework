using EpamPage;
using OpenQA.Selenium;

namespace EpamPageTests.StepDefinitions
{
    // Binding class for defining SpecFlow steps related to the Search page
    [Binding]
    public class SearchPageStep
    {
        // Private field to hold an instance of the SearchPage class for interacting with the Search page
        private readonly SearchPage _searchPage;

        // Constructor to initialize the SearchPage object with the WebDriver instance
        public SearchPageStep(IWebDriver driver)
        {
            _searchPage = new(driver);
        }

        // Step definition for opening the search bar
        [Given(@"I open the search bar")]
        public void GivenIOpenTheSearchBar()
        {
            _searchPage.ClickMagnifierIcon();
        }

        // Step definition for entering a search keyword
        [When(@"I enter a search keyword ""([^""]*)""")]
        public void WhenIEnterASearchKeyword(string keyword)
        {
            _searchPage.SendKeysSearch(keyword);
        }

        // Step definition for clicking the "Find" button and scrolling to the last search result
        [When(@"I clicks the Find button")]
        public void WhenIClicksTheFindButton()
        {
            _searchPage.ClickFindSearch();
            _searchPage.ScroolToLastLink();
        }

        // Step definition to validate if all search results contain the search term (with a special condition for the keyword "Cloud")
        [Then(@"All search results should contain the search term ""([^""]*)""")]
        public void ThenAllSearchResultsShouldContainTheSearchTerm(string keyword)
        {
            if (keyword == "Cloud")
                _searchPage.CheckIfAllLinksContainKeyword(keyword).Should().BeTrue();
            else if(keyword != "Cloud")
                _searchPage.CheckIfAllLinksContainKeyword(keyword).Should().BeFalse();
        }
    }
}
