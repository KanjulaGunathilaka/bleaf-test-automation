Feature: Login to BLeaf

@login @bvt @regression
Scenario: Admin User Login with valid credentials
	Given I navigate to the bleaf home page
	When I click on the login button
	And I login with username "admin@bleaf.com" and password "Admin@123"
	Then I should see the Admin dashboard link

	Scenario: Normal User Login with valid credentials
	Given I navigate to the bleaf home page
	When I click on the login button
	And I login with username "testuser@bleaf.com" and password "Test@123"
	Then I should not see the Admin dashboard link