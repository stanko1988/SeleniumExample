using OpenQA.Selenium;
using Extent = AventStack.ExtentReports.ExtentReports;
using AventStack.ExtentReports;
using static SeleniumExample.PageObject.Helpers.Extensions;
using System.Collections.Generic;
using System;
using System.Linq;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;

namespace SeleniumExample.PageObject.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver, Extent extentReports = null, ExtentTest extentTest = null)
            : base(webDriver, extentReports, extentTest)
        {
        }
        
        public IWebElement HotelsButton => FindElement(WebDriver, By.XPath("//*[@data-name='hotels']"));
        public IWebElement DestinationDropDown => FindElement(WebDriver, By.Id("s2id_autogen16"));
        public IWebElement SelectDropdownSearch => FindElement(WebDriver, By.XPath("//*[@id='select2-drop']/div/input"));
        public IWebElement CheckInPicker => FindElement(WebDriver, By.Id("checkin"));
        public IWebElement CheckOutPicker => FindElement(WebDriver, By.Id("checkout"));
        public IWebElement CheckInPickerContainer => FindElement(WebDriver, By.XPath("//div[@class='datepicker -bottom-left- -from-bottom- active']"));
        public IList<IWebElement> CheckInPickerDays => CheckInPickerContainer.FindElements(By.ClassName("datepicker--cell-day"));
        public IList<IWebElement> DropDownItems => WebDriver.FindElement(By.XPath("//*[@id='select2-drop']")).FindElements(By.ClassName("select2-result-label"));
        public IWebElement ChildrenOption => FindElement(WebDriver, By.XPath("//*[@id='hotels']/div/div/form/div/div/div[3]/div/div/div/div/div/div/div[2]/div/div[2]/div/span/button[1]"));
        public IWebElement SubmitBtn => FindElement(WebDriver, By.XPath("//button[contains(text(),'Search')]"));
        
        public HomePage SelectHotels()
        {
            HotelsButton.Click();
            AddStepInfo("Hotels Selected");

            return this;
        }

        public HomePage OpenDestinationPickerAndChoose(string destination)
        {
            DestinationDropDown.Click();
            var a = destination.Substring(0, destination.IndexOf(","));
            SelectDropdownSearch.SendKeys(a);
            AddStepInfo("Destination Picker");

            var item = DropDownItems.Where(x => x.Text == destination);

            item.FirstOrDefault().Click();

            //can be done in this way
            //var size = DropDownItems.Count;

            //for (int i = 0; i < size; i++)
            //{
            //    var dropDownItem = DropDownItems[i];
            //    var dropDownItemText = DropDownItems[i].Text;
            //    if(dropDownItemText == destination)
            //    {
            //        dropDownItem.Click();
            //        break;
            //    }
            //}

            AddStepInfo("Search" + destination);

            return this;
        }

        public HomePage SelectCheckInDate(DateTime dateTime)
        {
            CheckInPicker.Click();
            AddStepInfo("Picker Is Open");
            ClickOnCalendar(dateTime);

            return this;
        }
        public HomePage SelectCheckOutDate(DateTime dateTime)
        {
            CheckOutPicker.Click();
            AddStepInfo("Picker Is Open");
            ClickOnCalendar(dateTime);

            return this;
        }

        public HomePage ClickOnChildrenButton()
        {
            ChildrenOption.Click();

            AddStepInfo("Added One Child");
            return this;
        }

        public HomePage ClickOnsubmitButton()
        {
            SubmitBtn.Click();

            return this;
        }

        public void ClickOnCalendar(DateTime dateTime)
        {
            var date = CheckInPickerDays.Where(CheckInPickerDay => (CheckInPickerDay.GetAttribute("data-date") == dateTime.Day.ToString()) &&
                                                                 (CheckInPickerDay.GetAttribute("data-month") == dateTime.Month.ToString()) &&
                                                                 (CheckInPickerDay.GetAttribute("data-year") == dateTime.Year.ToString()));

            date.FirstOrDefault().Click();
            AddStepInfo("Selected Date is " + dateTime);

            //Can be done also in this way
            //var size = CheckInPickerDays.Count();
            //for(int i=0; i < size; i++)
            //{
            //    var item = CheckInPickerDays[i];
            //    if (item.GetAttribute("data-date") == dateTime.Day.ToString())
            //        //&& item.GetAttribute("data-month") == dateTime.Month.ToString()
            //        //&& item.GetAttribute("data-year") == dateTime.Year.ToString())
            //    {
            //        item.Click();
            //        break;
            //    }

            //}
        }

    }
}
