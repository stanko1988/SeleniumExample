namespace SeleniumExample.Core.SeleniumDriverFactory
{
    public class DriverManagerFactory
    {
        public static DriverManager GetDriverManager(DriverType.DriverType driverType)
        {
            DriverManager driverManager;

            switch (driverType)
            {
                case DriverType.DriverType.Chrome:
                    driverManager = new ChromeDriverManager();
                    break;
                case DriverType.DriverType.Firefox:
                    driverManager = new FirefoxDriverManager();
                    break;
                default:
                    driverManager = new ChromeDriverManager();
                    break;
            }

            return driverManager;
        }
    }
}
