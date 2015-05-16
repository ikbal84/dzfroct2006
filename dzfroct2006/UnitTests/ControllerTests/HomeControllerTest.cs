using NUnit.Framework;
using System.Web.Mvc;
using dzfroct2006.Controllers;


namespace UnitTests.ControllerTests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void TestIndex()
        {
            var HomeController = new dzfroct2006.Controllers.HomeController();
            var result = HomeController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
