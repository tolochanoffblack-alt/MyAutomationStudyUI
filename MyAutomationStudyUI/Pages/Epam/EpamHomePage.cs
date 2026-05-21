using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class EpamHomePage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By careersButton = By.LinkText("Careers");
        private readonly By aboutButton = By.CssSelector("a.top-navigation__item-link[href='/about']");
        private readonly By insightsButton = By.CssSelector("a.top-navigation__item-link[href='/insights']");

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.epam.com");
        }

        public CareersPage ClickCareers()
        {
            WaitUntilClickable(careersButton).Click();
            return new CareersPage(driver);
        }

        public AboutPage ClickAbout()
        {
            var element = WaitUntilClickable(aboutButton);
            element.Click();

            return new AboutPage(driver);
        }

        public InsightsPage ClickInsights()
        {
            var element = WaitUntilClickable(insightsButton);
            element.Click();

            return new InsightsPage(driver);


        }
    }
}