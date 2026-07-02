using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.SauceDemo
{
    public class SauceInventoryPage : BasePage
    {
        private readonly By _pageTitle = By.ClassName("title");
        private readonly By _productItemContainer = By.CssSelector("[data-test='inventory-item']");
        private readonly By _productNameInItem = By.CssSelector("[data-test='inventory-item-name']");
        private readonly By _cartLink = By.CssSelector("[data-test='shopping-cart-link']");

        public SauceInventoryPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPageTitle()
        {
            var titleElement = WaitUntilVisible(_pageTitle);
            return titleElement.Text?.Trim() ?? string.Empty;
        }

        public void AddProductToCart(string productName)
        {
            var productContainers = driver.FindElements(_productItemContainer);

            foreach (var container in productContainers)
            {
                var productNameElement = container.FindElement(_productNameInItem);
                if (productNameElement.Text.Trim().Equals(productName, System.StringComparison.OrdinalIgnoreCase))
                {
                    var addToCartButton = container.FindElement(
                        By.CssSelector("[data-test*='add-to-cart']")
                    );
                    addToCartButton.Click();
                    return;
                }
            }

            throw new NoSuchElementException($"Product '{productName}' not found in inventory.");
        }

        public SauceShoppingCartPage ClickCartLink()
        {
            var cartLinkElement = WaitUntilClickable(_cartLink);
            cartLinkElement.Click();
            return new SauceShoppingCartPage(driver);
        }
    }
}
