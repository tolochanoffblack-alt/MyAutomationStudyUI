using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.SauceDemo
{
    public class SauceInventoryPage : BasePage
    {
        private readonly By _pageTitle = By.ClassName("title");

        public SauceInventoryPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPageTitle()
        {
            var titleElement = WaitUntilVisible(_pageTitle);
            return titleElement.Text?.Trim() ?? string.Empty;
        }
    }
}
