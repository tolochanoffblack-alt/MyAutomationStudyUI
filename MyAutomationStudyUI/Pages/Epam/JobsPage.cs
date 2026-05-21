using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class JobsPage : BasePage
    {
        private readonly By searchInput = By.CssSelector("input[data-testid='search-input']");

        public JobsPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterSearchText(string text)
        {
            var element = WaitUntilVisible(searchInput);
            element.Clear();
            element.SendKeys(text);
        }

        public void PressEnter()
        {
            WaitUntilVisible(searchInput).SendKeys(Keys.Enter);
        }

        public bool IsSearchTextPresent(string text)
        {
            return WaitUntilTextExistsInPage(text);
        }
    }
}
