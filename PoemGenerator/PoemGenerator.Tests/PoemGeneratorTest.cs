using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoemGenerator.Controllers;
using System.Web.Mvc;

namespace PoemGenerator.Tests
{
    [TestClass]
    public class PoemGeneratorTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }


    }
}
