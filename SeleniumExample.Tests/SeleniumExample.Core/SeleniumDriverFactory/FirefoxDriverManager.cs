using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace SeleniumExample.Core.SeleniumDriverFactory
{
    public class FirefoxDriverManager : DriverManager
    {
        protected override void CreateWebDriver()
        {
            Driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

    }
}
