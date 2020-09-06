using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Extent = AventStack.ExtentReports.ExtentReports;

namespace SeleniumExample.PageObject
{
    public class BasePage
    {
        public IWebDriver WebDriver;
        public Extent ExtentReports;
        public ExtentTest ExtentTest;
        public string AttachmentUrl => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public BasePage(IWebDriver webDriver, Extent extentReports, ExtentTest extentTest)
        {
            WebDriver = webDriver;
            ExtentReports = extentReports;
            ExtentTest = extentTest;
        }

        public void AddStepInfo(string StepName)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Screenshot img = WebDriver.TakeScreenshot();
            var imgPath = AttachmentUrl + "\\" + Guid.NewGuid();
            img.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            ExtentTest.Log(Status.Info, StepName + "<a href='" + imgPath + "' data-featherlight='image'  style='display: block;'><img src='" + imgPath + "' height='200' width='350' style='display: block;'></ a >");
        }
    }
}
