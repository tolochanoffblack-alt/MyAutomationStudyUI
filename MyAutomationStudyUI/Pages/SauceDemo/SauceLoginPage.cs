using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.SauceDemo
{
    public class SauceLoginPage : BasePage
    {
        private readonly By _username = By.Id("user-name");
        private readonly By _password = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _loginError = By.CssSelector("[data-test='error']");

        public SauceLoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public SauceInventoryPage Login(string username, string password)
        {
            var userInput = WaitUntilVisible(_username);
            userInput.Clear();
            userInput.SendKeys(username);

            var passInput = WaitUntilVisible(_password);
            passInput.Clear();
            passInput.SendKeys(password);

            var loginBtn = WaitUntilClickable(_loginButton);
            loginBtn.Click();

            return new SauceInventoryPage(driver);
        }

        public string GetErrorMessage()
        {
            var errorElement = WaitUntilVisible(_loginError);
            return errorElement.Text?.Trim() ?? string.Empty;
        }


    }
}
