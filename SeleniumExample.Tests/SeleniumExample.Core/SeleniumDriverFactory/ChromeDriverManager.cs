using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniumExample.Core.SeleniumDriverFactory
{
    public class ChromeDriverManager : DriverManager
    {
        protected override void CreateWebDriver()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

    }
}
