Feature: About Page Download Functionality
Background: Given I navigate to "https://www.epam.com/"

  Scenario: Validate that the "EPAM Company Overview" file can be downloaded
     Given I click About from the top menu
      When I scroll down to the EPAM at a Glance section
       And I click on the Download button
      Then I should have the file "EPAM_Corporate_Overview_Q4FY-2024.pdf" downloaded within five seconds