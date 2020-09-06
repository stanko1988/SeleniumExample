using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExample.PageObject.Helpers
{
    public static class Extensions
    {
        public static TimeSpan WaitForElementTime = TimeSpan.FromSeconds(10);

        public static IWebElement FindElement(IWebDriver webDriver, By by)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, WaitForElementTime);
                return wait.Until(d => d.FindElement(by));
            }
            catch
            {
                return null;
            }
        }

        public static IWebElement FindElementByText(IWebDriver webDriver, By by)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, WaitForElementTime);
                return wait.Until(d => d.FindElement(by));
            }
            catch
            {
                return null;
            }
        }

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            Console.WriteLine(text + " entered in the " + element + " field.");
        }

        public static bool IsDisplayed(IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(element + " is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(element + " is not Displayed.");
            }

            return result;
        }

        public static string GetInputFieldText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetInputFieldLenght(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static bool IsBorderColorRed(IWebElement element)
        {
            //var a = element.GetCssValue("border-color");
            if (element.GetCssValue("border-color") == "rgb(220, 53, 69)")
                return true;
            else
                return false;
        }
    }
}
