Feature: Services Page Navigation Functionality
Background: Given I navigate to "https://www.epam.com/"

 Scenario: Navigate to a Specific Service Section and Validate Content
     Given I click on the Services link in the main navigation menu
      When I select the service category "<Category>"
      Then The page title should contain "<Category>"
       And I should see the section "Our Related Expertise" displayed on the page

       Examples:
      | Category       |
      | Generative AI  |
      | Responsible AI |