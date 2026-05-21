using NUnit.Framework;
using MyAutomationStudyUI.Core;
using MyAutomationStudyUI.Pages;
using MyAutomationStudyUI.Pages.Epam;

namespace MyAutomationStudyUI.Tests.EpamTests
{
    public class EpamAboutTests : BaseTest
    {
        [Test]
        public void ValidateCodeOfEthicalConductPdfDownload()
        {
            var homePage = new EpamHomePage(driver);
            var aboutPage = new AboutPage(driver);
            var cookieBanner = new CookieBanner(driver);

            string fileName = "Code-Of-Conduct_01_26.pdf";

            DeleteFileIfExists(fileName);

            homePage.Open();

            cookieBanner.AcceptIfPresent();

            homePage.ClickAbout();

            cookieBanner.AcceptIfPresent();

            aboutPage.ClickEthicalConductPdf();

            Assert.That(WaitForFileDownloaded(fileName), Is.True,
                $"File '{fileName}' was not downloaded.");
        }
    }
}