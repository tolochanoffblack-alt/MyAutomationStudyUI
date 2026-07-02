using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.SauceDemo
{
    public class SauceShoppingCartPage : BasePage
    {
        private readonly By _cartItemContainer = By.CssSelector("[data-test='inventory-item']");
        private readonly By _productNameInCart = By.CssSelector("[data-test='inventory-item-name']");

        public SauceShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsProductInCart(string productName)
        {
            try
            {
                var cartItems = driver.FindElements(_cartItemContainer);

                foreach (var item in cartItems)
                {
                    var productNameElement = item.FindElement(_productNameInCart);
                    if (productNameElement.Text.Trim().Equals(productName, System.StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
