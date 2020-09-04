using OpenQA.Selenium;

namespace SeleniumExample.Core.SeleniumDriverFactory
{
    public abstract class DriverManager
    {
        protected IWebDriver Driver;
        protected abstract void CreateWebDriver();


        public void QuitWebDriver()
        {
            if (Driver == null) return;
            Driver.Quit();
            Driver = null;
        }

        public IWebDriver GetWebDriver()
        {
            if (Driver == null)
                CreateWebDriver();
            return Driver;
        }
    }
}
