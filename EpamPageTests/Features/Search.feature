Feature: Search Page Magnifier Functionality
Background: Given I navigate to "https://www.epam.com/"

Scenario:Navigate to the Epam page and perform a search
   Given I open the search bar 
    When I enter a search keyword "<keyword>" 
     And I clicks the Find button 
    Then All search results should contain the search term "<keyword>"

Examples:
| keyword     |
| BLOCKCHAIN  |
| Cloud       |
| Automation  |
