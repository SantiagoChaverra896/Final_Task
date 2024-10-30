using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        //Login Page Locators
        private readonly By _userNameInput = By.XPath("//input[@data-test='username']");
        private readonly By _passwordInput = By.XPath("//input[@data-test='password']");
        private readonly By _loginButton = By.XPath("//input[@id='login-button']");
        public readonly By _errorMessage = By.XPath("//input[@id='//h3[@data-test='error']");
               

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterUserName(string userName)
        {
            _driver.FindElement(_userNameInput).SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordInput).SendKeys(password);
        }

        public void ClickLoginButton() 
        {
            _driver.FindElement(_loginButton).Click();
        }

        public void ClearUserName()
        {
            _driver.FindElement(_userNameInput).Clear();
        }

        public void ClearPassword() 
        {
            _driver.FindElement(_passwordInput).Clear();
        }




    }
}
