Feature: Home Page

  Background:
    Given I navigate to the home page

  Scenario: Verify home page elements
    Then the home page should display the logo
    And the home page should display the search bar
    And the home page should display the header panel

  Scenario: Login and navigate to order checkout
    When I click on the login button
    And I login with username "admin@bleaf.com" and password "Admin@123"
    And I select the menu item "Rice"
    And I proceed to checkout
    Then the checkout page should display the order summary