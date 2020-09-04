using OpenQA.Selenium;
using SeleniumExample.Core.SeleniumDriverFactory;

namespace SeleniumExample.Core
{
    public class WebDriverInitializer
    {
        public static IWebDriver Initialize(DriverType.DriverType driverType)
        {
            return DriverManagerFactory.GetDriverManager(driverType).GetWebDriver();
        }
    }
}
