using NUnit.Framework;
using MyAutomationStudyUI.Core;
using MyAutomationStudyUI.Pages;
using MyAutomationStudyUI.Pages.Epam;

namespace MyAutomationStudyUI.Tests.EpamTests
{
    public class EpamCareersTests : BaseTest
    {
        [Test]
        public void SearchAutomationJobsFromHomePage()
        {
            var homePage = new EpamHomePage(driver);
            var careersPage = new CareersPage(driver);
            var jobsPage = new JobsPage(driver);
            var cookieBanner = new CookieBanner(driver);

            homePage.Open();

            cookieBanner.AcceptIfPresent();

            homePage.ClickCareers();

            cookieBanner.AcceptIfPresent();

            careersPage.ClickStartYourSearchHere();

            jobsPage.EnterSearchText("automation");
            jobsPage.PressEnter();

            Assert.That(jobsPage.IsSearchTextPresent("automation"), Is.True);
        }
    }

}