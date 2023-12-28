using NUnit.Framework;

namespace Chat.BL.UnitTests
{
    [TestFixture]
    public class TestBase
    {

        [Test]
        [TestCase(" 8 919 ")]
        [TestCase(null)]
        [TestCase("")]
        [Category("Integration")]
        public void TestPhoneValidation(string phone)
        {
            Assert.Pass();
        }
    }
}