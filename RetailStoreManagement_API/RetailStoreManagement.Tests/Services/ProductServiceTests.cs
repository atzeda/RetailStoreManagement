using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;
using RetailStoreManagement.Services;
using Xunit;

namespace RetailStoreManagement.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Item1", Price = 100, Stock = 10 },
                new Product { Id = 2, Name = "Item2", Price = 200, Stock = 5 }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsProduct()
        {
            var product = new Product { Id = 1, Name = "Item1", Price = 100, Stock = 10 };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Item1", result.Name);
        }

        [Fact]
        public async Task AddAsync_ReturnsCreatedProduct()
        {
            var product = new Product { Name = "NewProduct", Price = 150, Stock = 20 };
            _mockRepo.Setup(r => r.AddAsync(product)).ReturnsAsync(product);

            var result = await _service.AddAsync(product);

            Assert.Equal("NewProduct", result.Name);
        }

        [Fact]
        public async Task DeleteAsync_CallsRepository()
        {
            // Arrange
            int customerId = 1;
            _mockRepo.Setup(r => r.DeleteAsync(customerId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteAsync(customerId);

            // Assert
            _mockRepo.Verify(r => r.DeleteAsync(customerId), Times.Once);
        }
    }
}