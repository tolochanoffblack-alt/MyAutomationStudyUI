using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text;
using System.Text.Json;

namespace MyAutomationStudyUI.Tools.UiInspector
{
    public static class SauceDemoDomInspector
    {
        private const string SauceDemoUrl = "https://www.saucedemo.com/";
        private const string StandardUser = "standard_user";
        private const string Password = "secret_sauce";
        private const string ProductName = "Sauce Labs Backpack";

        public static void CaptureCartFlowDom()
        {
            var outputDirectory = Path.Combine(GetProjectRootDirectory(), "UiInspection");
            Directory.CreateDirectory(outputDirectory);

            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");

            using var driver = new ChromeDriver(options);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Navigate().GoToUrl(SauceDemoUrl);

            driver.FindElement(By.Id("user-name")).SendKeys(StandardUser);
            driver.FindElement(By.Id("password")).SendKeys(Password);
            driver.FindElement(By.Id("login-button")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='inventory-container']")));

            var backpackItem = driver.FindElement(
                By.XPath($"//*[text()='{ProductName}']/ancestor::*[@data-test='inventory-item']"));

            var addToCartButton = backpackItem.FindElement(By.TagName("button"));
            var cartLink = driver.FindElement(By.CssSelector("[data-test='shopping-cart-link']"));

            var inventorySnapshots = new List<ElementSnapshot>
            {
                CreateElementSnapshot("Inventory Backpack Item", backpackItem),
                CreateElementSnapshot("Inventory Backpack Add To Cart Button", addToCartButton),
                CreateElementSnapshot("Shopping Cart Link", cartLink)
            };

            addToCartButton.Click();
            cartLink.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='cart-list']")));

            var cartItem = driver.FindElement(By.CssSelector("[data-test='inventory-item']"));
            var cartItemName = cartItem.FindElement(By.CssSelector("[data-test='inventory-item-name']"));

            var cartSnapshots = new List<ElementSnapshot>
            {
                CreateElementSnapshot("Cart Item", cartItem),
                CreateElementSnapshot("Cart Item Name", cartItemName)
            };

            var snapshot = new UiSnapshot(
                Name: "SauceDemo Cart Flow",
                Url: driver.Url,
                CapturedAtUtc: DateTime.UtcNow,
                Elements: inventorySnapshots.Concat(cartSnapshots).ToList());

            var json = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(
                Path.Combine(outputDirectory, "saucedemo-cart-flow-snapshot.json"),
                json);

            File.WriteAllText(
                Path.Combine(outputDirectory, "ui-inspector-input.md"),
                BuildInspectorInput(json));
        }

        private static ElementSnapshot CreateElementSnapshot(string name, IWebElement element)
        {
            return new ElementSnapshot(
                Name: name,
                TagName: element.TagName,
                Text: element.Text,
                DataTest: element.GetAttribute("data-test"),
                Id: element.GetAttribute("id"),
                NameAttribute: element.GetAttribute("name"),
                Class: element.GetAttribute("class"),
                AriaLabel: element.GetAttribute("aria-label"),
                Href: element.GetAttribute("href"),
                IsDisplayed: element.Displayed,
                IsEnabled: element.Enabled,
                OuterHtml: element.GetAttribute("outerHTML"));
        }

        private static string BuildInspectorInput(string json)
        {
            var builder = new StringBuilder();

            builder.AppendLine("# UI Inspector Input");
            builder.AppendLine();
            builder.AppendLine("Use this captured DOM snapshot as verified source.");
            builder.AppendLine();
            builder.AppendLine("Analyze locators for SauceDemo cart flow.");
            builder.AppendLine();
            builder.AppendLine("Do not generate Selenium code.");
            builder.AppendLine("Do not generate tests.");
            builder.AppendLine();
            builder.AppendLine("Return:");
            builder.AppendLine();
            builder.AppendLine("1. Verified locators");
            builder.AppendLine("2. Recommended Page Object methods");
            builder.AppendLine("3. Wait strategy");
            builder.AppendLine("4. Risks");
            builder.AppendLine("5. Recommended next step");
            builder.AppendLine();
            builder.AppendLine("JSON Snapshot:");
            builder.AppendLine(json);

            return builder.ToString();
        }

        private static string GetProjectRootDirectory()
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);

            while (directory != null)
            {
                if (directory.GetFiles("MyAutomationStudyUI.csproj").Any())
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            return Directory.GetCurrentDirectory();
        }

        private sealed record UiSnapshot(
            string Name,
            string Url,
            DateTime CapturedAtUtc,
            IReadOnlyCollection<ElementSnapshot> Elements);

        private sealed record ElementSnapshot(
            string Name,
            string TagName,
            string Text,
            string? DataTest,
            string? Id,
            string? NameAttribute,
            string? Class,
            string? AriaLabel,
            string? Href,
            bool IsDisplayed,
            bool IsEnabled,
            string? OuterHtml);
    }
}