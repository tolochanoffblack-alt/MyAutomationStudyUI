using NUnit.Framework;
using MyAutomationStudyUI.Core;
using MyAutomationStudyUI.Pages.SauceDemo;
using MyAutomationStudyUI.TestData;

namespace MyAutomationStudyUI.Tests.SauceDemo
{
    public class SauceShoppingCartTests : BaseTest
    {
        [Test]
        public void AddProductToCart_AndVerifyInCart()
        {
            // Arrange
            var productName = SauceDemoMessages.SauceLabsBackpackName;
            var loginPage = new SauceLoginPage(driver);

            // Act - Login
            loginPage.Open();
            var inventoryPage = loginPage.Login(SauceDemoUsers.StandardUser, SauceDemoUsers.Password);

            // Act - Add product to cart
            inventoryPage.AddProductToCart(productName);

            // Act - Navigate to cart
            var cartPage = inventoryPage.ClickCartLink();

            // Assert
            Assert.That(cartPage.IsProductInCart(productName), Is.True);
        }
    }
}
