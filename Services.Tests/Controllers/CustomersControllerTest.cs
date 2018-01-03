using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.Controllers;

namespace Services.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            
            // Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
