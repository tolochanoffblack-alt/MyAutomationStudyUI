using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class CookieBanner : BasePage
    {
        private readonly By acceptButton = By.Id("onetrust-accept-btn-handler");

        public CookieBanner(IWebDriver driver) : base(driver)
        {
        }

        public void AcceptIfPresent()
        {
            try
            {
                WaitUntilClickable(acceptButton).Click();
            }
            catch
            {
            }
        }
    }
}