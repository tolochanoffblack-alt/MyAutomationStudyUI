using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class InsightsPage : BasePage
    {
        // Locators
        private readonly By _carouselNext = By.XPath("(//div[contains(@class,'slider__navigation')]//button[contains(@class,'slider__right-arrow')])[1]");
        private readonly By _activeArticleTitle = By.XPath("(//div[contains(@class,'owl-item active')]//span[contains(@class,'museo-sans-light')])[1]");
        private readonly By _activeReadMore = By.XPath("(//div[contains(@class,'owl-item active')]//a[contains(@class,'slider-cta-link')])[1]");

        public InsightsPage(IWebDriver driver) : base(driver)
        {
        }

        public void SwipeCarouselTwice()
        {
            for (int i = 0; i < 2; i++)
            {
                var next = WaitUntilClickable(_carouselNext);
                next.Click();

                // Ensure the active article title is visible after the swipe
                WaitUntilVisible(_activeArticleTitle);
            }
        }

        public string GetActiveArticleTitle()
        {
            var titleElement = WaitUntilVisible(_activeArticleTitle);
            return titleElement.Text?.Trim() ?? string.Empty;
        }

        public void ClickReadMore()
        {
            var readMore = WaitUntilClickable(_activeReadMore);
            readMore.Click();
        }
    }
}
