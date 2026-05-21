using NUnit.Framework;
using MyAutomationStudyUI.Core;
using MyAutomationStudyUI.Pages;
using MyAutomationStudyUI.Pages.Epam;

namespace MyAutomationStudyUI.Tests.EpamTests
{
    public class EpamInsightsTests : BaseTest
    {
        [Test]
        public void ValidateArticleTitleMatchesCarouselTitle()
        {
            var homePage = new EpamHomePage(driver);
            homePage.Open();

            var insightsPage = homePage.ClickInsights();
            insightsPage.SwipeCarouselTwice();

            var carouselTitle = insightsPage.GetActiveArticleTitle();

            insightsPage.ClickReadMore();

            var articlePage = new ArticlePage(driver);
            var articleTitle = articlePage.GetArticleTitle();

            Assert.That(articleTitle, Is.EqualTo(carouselTitle));
        }
    }
}
