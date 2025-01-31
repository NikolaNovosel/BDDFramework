Feature: Insights page article swipe functionality
Background: Given I navigate to "https://www.epam.com/"

Scenario: Validate title of the article matches with title in the carousel
Given I click Insights from the top menu
 When I swipe the carousel twice
  And I note the name of the article
  And I click the Read More button
 Then The article title should match with the noted above
