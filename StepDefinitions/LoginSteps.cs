using bleaf_test_automation.Pages;
using bleaf_test_automation.TestBase;
using NUnit.Framework;

namespace bleaf_test_automation.StepDefinitions
{
    [Binding]
    public class LoginSteps : BaseTest
    {
        private HomePage _homePage;
        private LoginPage _loginPage;

        [Given(@"I navigate to the bleaf home page")]
        public void GivenINavigateToTheHomePage()
        {
            Console.WriteLine("Initializing HomePage...");
            _homePage = new HomePage();
            Console.WriteLine("HomePage initialized.");
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            _homePage.ClickLoginButton();
            _loginPage = new LoginPage();
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            _loginPage.Login(username, password);
        }

        [Then(@"I (should|should not) see the Admin dashboard link")]
        public void ThenIShouldSeeTheUserDashboard(string visibilityOfLink)
        {
            bool isDashboardDisplayed = _loginPage.IsUserDashboardDisplayed();
            bool expectedVisibility = visibilityOfLink == "should";

            Assert.That(isDashboardDisplayed, Is.EqualTo(expectedVisibility),
                $"Expected the Admin dashboard link to be {(expectedVisibility ? "displayed" : "not displayed")}, but it was {(isDashboardDisplayed ? "displayed" : "not displayed")}.");
        }
    }
}