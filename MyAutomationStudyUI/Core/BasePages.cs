using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyAutomationStudyUI.Core
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected bool WaitUntilTextExistsInPage(string text)
        {
            return wait.Until(d => d.PageSource.ToLower().Contains(text.ToLower()));
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void ScrollToElementCenter(IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({ block: 'center' });", element);
        }

        protected void ClickWithJavaScript(IWebElement element)
        {
            ((IJavaScriptExecutor)(driver))
                .ExecuteScript("arguments[0].click();", element);
        }
    }
}