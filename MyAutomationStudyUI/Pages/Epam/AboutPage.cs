using OpenQA.Selenium;
using MyAutomationStudyUI.Core;

namespace MyAutomationStudyUI.Pages.Epam
{
    public class AboutPage : BasePage
    {
        private readonly By ethicalConductPdfLink = By.XPath("//a[contains(@href,'Code-Of-Conduct') and contains(.,'Code of Ethical Conduct')]");

        public AboutPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickEthicalConductPdf()
        {
            var element = WaitUntilVisible(ethicalConductPdfLink);
            ScrollToElementCenter(element);
            ClickWithJavaScript(element);
        }

       
    }
}
