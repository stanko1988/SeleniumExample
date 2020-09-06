using OpenQA.Selenium;
using Extent = AventStack.ExtentReports.ExtentReports;
using AventStack.ExtentReports;
using static SeleniumExample.PageObject.Helpers.Extensions;

namespace SeleniumExample.PageObject.Pages
{
    public class SearchResults : BasePage
    {
        public SearchResults(IWebDriver webDriver, Extent extentReports = null, ExtentTest extentTest = null)
           : base(webDriver, extentReports, extentTest)
        {
        }

        public IWebElement FirstResult => FindElement(WebDriver, By.ClassName("product-long-item"));

        public bool IsResultDisplayed()
        {
            AddStepInfo("Search Result");
           return FirstResult.Displayed;
        }
    }
}
