using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExample.Core.DriverType;
using Extent = AventStack.ExtentReports.ExtentReports;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using AventStack.ExtentReports.Reporter.Configuration;
using System.IO;
using SeleniumExample.Core;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExample.Tests.Constants;
using SeleniumExample.PageObject.Pages;

namespace SeleniumExample.Tests
{
    [TestFixture(DriverType.Chrome)]
   // [TestFixture(DriverType.Firefox)]
    public class BaseTest
    {
        public IWebDriver WebDriver;
        public DriverType DriverType;
        protected Extent ExtentReports;
        protected ExtentTest ExtentTest;
        protected TestStatus TestStatus;
        protected Status LogStatus;


        public HomePage HomePage { get; set; }

        public BaseTest(DriverType driverType)
        {
            DriverType = driverType;
        }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            ExtentReports = new Extent();
            var reporter = (new ExtentHtmlReporter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "..\\..\\..\\..\\..\\Reports\\Report " + DateTime.Now.ToString("yyyyMMdd-hms").Replace('/', ' ') + "\\ExtentReport.html"));
            reporter.Config.DocumentTitle = "SeleniumExample";
            reporter.Config.Theme = Theme.Dark;
            ExtentReports.AttachReporter(reporter);
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            ExtentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriver = WebDriverInitializer.Initialize(DriverType);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(PageUrls.LoginPageUrl);

            Initialize();

        }

        public void Initialize()
        {
            HomePage = new HomePage(WebDriver, ExtentReports, ExtentTest);
        }


        [TearDown]
        public void AfterEachTest()
        {
            TestStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : TestContext.CurrentContext.Result.StackTrace;
            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                ? ""
                : TestContext.CurrentContext.Result.Message;

            switch (TestStatus)
            {
                case TestStatus.Failed:
                    LogStatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    LogStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    LogStatus = Status.Skip;
                    break;
                case TestStatus.Passed:
                    LogStatus = Status.Pass;
                    break;
                default:
                    LogStatus = Status.Pass;
                    break;
            }

            Screenshot img = WebDriver.TakeScreenshot();
            var imgPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Guid.NewGuid();
            img.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            ExtentTest.Log(LogStatus, "<strong>" + LogStatus + TestStatus + "</strong><a href='" + imgPath + "' data-featherlight='image'  style='display: block;'><img src='" + imgPath + "' height='200' width='350' style='display: block;'></ a >");

            ExtentTest.AssignDevice(DriverType.ToString());

            ExtentReports.Flush();

            WebDriver.Close();
            WebDriver.Quit();
        }


        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ExtentReports.Flush();

            //WebDriver.Close();
            //WebDriver.Quit();
        }
    }
}
