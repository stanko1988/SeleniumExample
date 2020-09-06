using NUnit.Framework;
using SeleniumExample.Core.DriverType;
using SeleniumExample.TestProject;
using System;

namespace SeleniumExample.TestProject
{
    public class TestCases : BaseTest
    {
        public TestCases(DriverType driverType)
         : base(driverType)
        { }

        [SetUp]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
        }

        [Test]
        public void SampleTestCase()
        {
            HomePage
                .SelectHotels()
                .OpenDestinationPickerAndChoose("London, United Kingdom")
                .SelectCheckInDate(new DateTime(2020, 8, 12))
                .SelectCheckOutDate(new DateTime(2020, 8, 15))
                .ClickOnChildrenButton()
                .ClickOnsubmitButton();

            Assert.IsTrue(SearchResults.IsResultDisplayed());

        }
    }
}
