using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Final_Task.Utilities;
using FluentAssertions;

namespace Final_Task.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private IWebDriver driver;

        //  Use ScenarioContext to store the browser type, if passed from the feature file
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"A user is using the ""([^""]*)"" browser")]
        public void GivenAUserIsUsingTheBrowser(string browserType)
        {
            driver = BrowserFactory.CreateDriver(browserType);  // Get browser from BrowserFactory
            _scenarioContext["driver"] = driver;  // Store driver in ScenarioContext
            driver.Url = "https://www.saucedemo.com";
        }

        [Given(@"A user opened the Browser")]
        public void GivenAUserOpenedTheBrowser()
        {
            driver = new EdgeDriver();
        
            
            driver.Url = "https://www.saucedemo.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"The user clicks the Login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            driver.FindElement(By.XPath("//input[@id='login-button']")).Click();
        }

        [Then(@"The application should display the error message: Username is required")]
        public void ThenTheApplicationShouldDisplayTheErrorMessageUsernameIsRequired()
        {
            string errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            errorMessage.Should().Be("Epic sadface: Username is required", $"Expected error message to be 'Epic sadface: Username is required', but was '{errorMessage}'");
         
        }

        [Given(@"The user types any credentials into the username field")]
        public void GivenTheUserTypesAnyCredentialsIntoTheUsernameField()
        {
            driver.FindElement(By.XPath("//input[@data-test='username']")).SendKeys("AnyUsername");
        }

        [Then(@"The application should display the error message: Password is required")]
        public void ThenTheApplicationShouldDisplayTheErrorMessagePasswordIsRequired()
        {
            string errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            errorMessage.Should().Be("Epic sadface: Password is required", "because the error message should indicate that the password is required, but was '{0}'", errorMessage);

        }

        [Given(@"The user types a valid value into the username field")]
        public void GivenTheUserTypesAValidValueIntoTheUsernameField()
        {
            driver.FindElement(By.XPath("//input[@data-test='username']")).SendKeys("standard_user");
        }

        [Given(@"The user types a valid password into the password field")]
        public void GivenTheUserTypesAValidPasswordIntoThePasswordField()
        {
            driver.FindElement(By.XPath("//input[@data-test='password']")).SendKeys("secret_sauce");
        }

        [Given(@"The user types a valid ""([^""]*)"" into the username field")]
        public void GivenTheUserTypesAValidIntoTheUsernameField(string username)
        {
            driver.FindElement(By.XPath("//input[@data-test='username']")).SendKeys(username);
        }

        [Given(@"The user types a valid ""([^""]*)"" into the password field")]
        public void GivenTheUserTypesAValidIntoThePasswordField(string password)
        {
            driver.FindElement(By.XPath("//input[@data-test='password']")).SendKeys(password);
        }


        [Then(@"The application should lead the user to the dashboard page with the title: Swag Labs")]
        public void ThenTheApplicationShouldLeadTheUserToTheDashboardPageWithTheTitleSwagLabs()
        {
            string dashboardTitle = driver.Title;
            dashboardTitle.Should().Be("Swag Labs","because the page title should be 'Swag Labs' when the user is led to the dashboard");
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }



    }
}
