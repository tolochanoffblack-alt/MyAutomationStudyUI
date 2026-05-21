using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class ArticlePage : BasePage
    {
        private readonly By _articleTitle = By.TagName("h1");

        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetArticleTitle()
        {
            var titleElement = WaitUntilVisible(_articleTitle);
            return titleElement.Text?.Trim() ?? string.Empty;
        }
    }
}
