Feature: Careers Page Job Search Functionality
Background: Given I navigate to "https://www.epam.com/"

Scenario: Search for a job based on criteria
   Given I click Careers from the top menu
	When I enter the keyword ".NET" in the Keyword field
	 And I select All locations from the Location dropdown
	 And I select the Remote option
	 And I click the Find button
	 And I click on the View and apply button of the latest result
	Then Job description should contains the keyword ".NET"
