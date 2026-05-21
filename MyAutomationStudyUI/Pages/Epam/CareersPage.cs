using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class CareersPage : BasePage
    {
        private readonly By startSearchButton = By.CssSelector("a[href*='careers.epam.com/en/jobs']");

        public CareersPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickStartYourSearchHere()
        {
            WaitUntilClickable(startSearchButton).Click();
        }
    }
}