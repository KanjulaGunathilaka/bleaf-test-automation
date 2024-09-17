Feature: Category API

  Scenario: Admin user adds a new category
    Given I am an admin user
    And I have a new category with random name and description "Cold drinks"
    When I send a POST request to the category endpoint
    Then the response status code should be 201
    And the category name should be the random name used

  Scenario: Admin user edits an existing category
    Given I am an admin user
    And I have an existing category with ID from the created category
    And I update the category name to random name
    When I send a PUT request to the category endpoint
    Then the response status code should be 200
    And the category name should be the random name used

  Scenario: Admin user deletes a category
    Given I am an admin user
    And I have the category ID from the created category
    When I send a DELETE request to the category endpoint
    Then the response status code should be 204