using NUnit.Framework;
using MyAutomationStudyUI.Core;
using MyAutomationStudyUI.Pages.SauceDemo;
using MyAutomationStudyUI.TestData;

namespace MyAutomationStudyUI.Tests.SauceDemo
{
    public class SauceLoginTests : BaseTest
    {
        [Test]
        public void Login_WithValidUser_OpensInventoryPage()
        {
            var loginPage = new SauceLoginPage(driver);
            loginPage.Open();

            var inventoryPage = loginPage.Login(SauceDemoUsers.StandardUser, SauceDemoUsers.Password);

            Assert.That(inventoryPage.GetPageTitle(), Is.EqualTo("Products"));
        }

        [Test]
        public void Login_WithInvalidPassword_ShowsErrorMessage()
        {
            var loginPage = new SauceLoginPage(driver);
            loginPage.Open();

            loginPage.Login(SauceDemoUsers.StandardUser, SauceDemoUsers.WrongPassword);

            var errorMessage = loginPage.GetErrorMessage();

            Assert.That(errorMessage, Does.Contain(SauceDemoMessages.InvalidPasswordError));
        }
    }
}
