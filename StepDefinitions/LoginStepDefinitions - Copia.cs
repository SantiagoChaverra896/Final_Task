using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Final_Task.Utilities;
using FluentAssertions;
using Final_Task.PageObjects;

namespace Final_Task.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        //  Use ScenarioContext to store the browser type, if passed from the feature file
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"A user is using the ""([^""]*)"" browser")]
        public void GivenAUserIsUsingTheBrowser(string browserType)
        {
            _driver = BrowserFactory.CreateDriver(browserType);  // Get browser from BrowserFactory
            _driver.Url = "https://www.saucedemo.com";
            _loginPage = new LoginPage(_driver);
        }

        [When(@"The user clicks the Login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"The application should display the error message: Username is required")]
        public void ThenTheApplicationShouldDisplayTheErrorMessageUsernameIsRequired()
        {
            string errorMessage = _driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            errorMessage.Should().Be("Epic sadface: Username is required", $"Expected error message to be 'Epic sadface: Username is required', but was '{errorMessage}'");
         
        }

        [Given(@"The user types any credentials into the username field")]
        public void GivenTheUserTypesAnyCredentialsIntoTheUsernameField()
        {
            _loginPage.EnterUserName("AnyValue");
        }

        [Then(@"The application should display the error message: Password is required")]
        public void ThenTheApplicationShouldDisplayTheErrorMessagePasswordIsRequired()
        {
            string errorMessage = _driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            errorMessage.Should().Be("Epic sadface: Password is required", "because the error message should indicate that the password is required, but was '{0}'", errorMessage);

        }

        [Given(@"The user types a valid value into the username field")]
        public void GivenTheUserTypesAValidValueIntoTheUsernameField()
        {
            _loginPage.EnterUserName("standard_user");
        }

        [Given(@"The user types a valid password into the password field")]
        public void GivenTheUserTypesAValidPasswordIntoThePasswordField()
        {
            _loginPage.EnterPassword("secret_sauce");
        }

        [Given(@"The user types a valid ""([^""]*)"" into the username field")]
        public void GivenTheUserTypesAValidIntoTheUsernameField(string username)
        {
            _loginPage.EnterUserName(username); 
        }

        [Given(@"The user types a valid ""([^""]*)"" into the password field")]
        public void GivenTheUserTypesAValidIntoThePasswordField(string password)
        {
            _loginPage.EnterPassword(password);
        }


        [Then(@"The application should lead the user to the dashboard page with the title: Swag Labs")]
        public void ThenTheApplicationShouldLeadTheUserToTheDashboardPageWithTheTitleSwagLabs()
        {
            string dashboardTitle = _driver.Title;
            dashboardTitle.Should().Be("Swag Labs","because the page title should be 'Swag Labs' when the user is led to the dashboard");
        }

        [Given(@"The user types a valid username into the username field")]
        public void GivenTheUserTypesAValidUsernameIntoTheUsernameField()
        {
            _loginPage.EnterUserName("standard_user");
        }

        [Given(@"The user clears the password field")]
        public void GivenTheUserClearsThePasswordField()
        {
            _loginPage.ClearPassword();
        }

        [Given(@"The user clears the username field")]
        public void GivenTheUserClearsTheUsernameField()
        {
            _loginPage.ClearUserName();
;       }


        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }



    }
}
