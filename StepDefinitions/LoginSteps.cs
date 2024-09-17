using TechTalk.SpecFlow;
using NUnit.Framework;
using bleaf_test_automation.Pages;
using bleaf_test_automation.TestBase;

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
            _homePage = new HomePage();
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
            if (visibilityOfLink == "should")
            {
                Assert.Equals(_loginPage.IsUserDashboardDisplayed(), true);
            }
            else
            {
                Assert.Equals(_loginPage.IsUserDashboardDisplayed(), false);
            }
        }
    }
}