using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.Controllers;
using DataAccess.Entity;

namespace Services.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        int _productID = 0;

        [TestMethod]
        public void Get()
        {
            // Arrange
            ProductsController controller = new ProductsController();
            
            // Act

            IEnumerable<Product> result = controller.GetProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 1);
            Assert.IsNotNull(result.ElementAt(0).Name);
            Assert.IsNotNull(result.ElementAt(1).Name);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            Product result = controller.GetProduct(680).Queryable.FirstOrDefault();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ProductsController controller = new ProductsController();
            string uniqueName = new Random().Next(int.MinValue, int.MaxValue).ToString();

            Product newProduct = new Product { Name = "TEST - " + uniqueName, ProductNumber = uniqueName, StandardCost = 1, ListPrice = 9, SellStartDate = DateTime.UtcNow, rowguid = Guid.NewGuid(), ModifiedDate = DateTime.UtcNow };

            // Act
            IHttpActionResult result = controller.Post(newProduct);
            System.Web.Http.OData.Results.CreatedODataResult<Product> odataResult = (System.Web.Http.OData.Results.CreatedODataResult<Product>)result;
            _productID = odataResult.Entity.ProductID;
            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ProductsController controller = new ProductsController();
            Product modProduct = controller.GetProduct(_productID).Queryable.FirstOrDefault();
            System.Web.Http.OData.Delta<Product> delta = new System.Web.Http.OData.Delta<Product>(typeof(Product));
            delta.TrySetPropertyValue("Color", "Almond");

            // Act
            IHttpActionResult result = controller.Put(_productID, delta);
            
            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            controller.Delete(_productID);

            // Assert
        }
    }
}
