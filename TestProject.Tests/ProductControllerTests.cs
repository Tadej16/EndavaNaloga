using EndavaNaloga.Controllers;
using EndavaNaloga.Models;
using EndavaNaloga.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Tests
{
    public class ProductControllerTests
    {
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            var repo = new Storage();
            _controller = new ProductController(repo);
        }

        [Fact]
        public void AddNewProduct_ReturnsOkResult()
        {
            // Arrange
            string name = "Laptop";
            decimal minPrice = 100;
            decimal maxPrice = 1500;
            string categoryName = "Electronics";
            // Act
            var result = _controller.GetFilteredProducts(name, minPrice, maxPrice, categoryName);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByName_ReturnsOkResult()
        {
            // Arrange
            string name = "Laptop";
            // Act
            var result = _controller.GetFilteredProductsByName(name);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByMinPrice_ReturnsOkResult()
        {
            // Arrange
            decimal minPrice = 100;
            // Act
            var result = _controller.GetFilteredProductsByMinPrice(minPrice);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByMaxPrice_ReturnsOkResult()
        {
            // Arrange
            decimal maxPrice = 1500;
            // Act
            var result = _controller.GetFilteredProductsByMaxPrice(maxPrice);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByCategoryName_ReturnsOkResult()
        {
            // Arrange
            string categoryName = "Phone";
            // Act
            var result = _controller.GetFilteredProducts(null, null, null, categoryName);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByAllParams_ReturnsOkResult()
        {
            // Arrange
            string name = "Mo";
            decimal minPrice = 100;
            decimal maxPrice = 1500;
            string categoryName = "Computer Peripherals";
            // Act
            var result = _controller.GetFilteredProducts(name, minPrice, maxPrice, categoryName);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByNoParams_ReturnsOkResult()
        {
            // Arrange
            // Act
            var result = _controller.GetFilteredProducts(null, null, null, null);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByNonExistingCategory_ReturnsOkResult()
        {
            // Arrange
            string categoryName = "NonExistingCategory";
            // Act
            var result = _controller.GetFilteredProducts(null, null, null, categoryName);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FilterByNegativeMinPrice_ReturnsOkResult()
        {
            // Arrange
            decimal minPrice = -100;
            // Act
            var result = _controller.GetFilteredProducts(null, minPrice, null, null);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateProduct_ReturnsOkResult()
        {
            // Arrange
            var tempResult = _controller.GetFilteredProducts("Laptop", null, null, null);
            
            //Unwrap the OkObjectResult to get the actual products
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(tempResult);
            Product? product = Assert.IsType<List<Product>>(okResult.Value).FirstOrDefault();
            
            var updatedProduct = new Product("Updated Laptop", 1300.00m, 1);
            // Act
            var result = _controller.UpdateProduct(product.Id, updatedProduct);

            okResult = Assert.IsType<OkObjectResult>(result);
            Product returnedUpdatedProduct = Assert.IsType<Product>(okResult.Value);

            var getResult = _controller.GetProductById(product.Id);
            okResult = Assert.IsType<OkObjectResult>(getResult);
            Product fetchedProduct = Assert.IsType<Product>(okResult.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Laptop", returnedUpdatedProduct.Name);
            Assert.Equal(1300.00m, returnedUpdatedProduct.Price);
            Assert.Equal("Updated Laptop", fetchedProduct.Name);
            Assert.Equal("Updated Laptop", product.Name);
        }
    }
}