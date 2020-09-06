using NUnit.Framework;
using SeleniumExample.Core.DriverType;

namespace SeleniumExample.Tests.Tests
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

        }
    }
}
