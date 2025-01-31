using EpamPage;
using OpenQA.Selenium;

namespace EpamPageTests.StepDefinitions
{
    // Binding class for defining SpecFlow steps related to the Insights page
    [Binding]
    public class InsightsPageStep
    {
        // Private field to hold an instance of the InsightsPage class
        private readonly InsightsPage _insightsPage;

        // Private field to store the trimmed text of the article name from the main page
        private string? _mainPageArticleTextTrim;

        // Constructor to initialize the InsightsPage object with the WebDriver instance
        public InsightsPageStep(IWebDriver driver)
        {
            _insightsPage = new(driver);
        }

        // Step definition for clicking the "Insights" option from the top menu
        [Given(@"I click Insights from the top menu")]
        public void GivenIClickInsightsFromTheTopMenu()
        {
            _insightsPage.ClickInsight();
        }

        // Step definition for swiping the carousel twice
        [When(@"I swipe the carousel twice")]
        public void WhenISwipeTheCarouselTwice()
        {
            _insightsPage.SwipeCarousel();
        }

        // Step definition for noting the name of the article on the main page
        [When(@"I note the name of the article")]
        public void WhenINoteTheNameOfTheArticle()
        {
            _mainPageArticleTextTrim = _insightsPage.GetMainPageArticleTextTrim();
        }

        // Step definition for clicking the "Read More" button
        [When(@"I click the Read More button")]
        public void WhenIClickTheReadMoreButton()
        {
            _insightsPage.ClickReadMore();
        }

        // Step definition to validate if the article title matches the previously noted article name
        [Then(@"The article title should match with the noted above")]
        public void ThenTheArticleTitleShouldMatchWithTheNotedAbove()
        {
            _insightsPage.GetInsideArticleText().Should().Be(_mainPageArticleTextTrim);
        }
    }
}
