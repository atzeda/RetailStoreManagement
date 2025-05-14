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
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;
        private readonly CustomerService _service;

        public CustomerServiceTests()
        {
            _mockRepo = new Mock<ICustomerRepository>();
            _service = new CustomerService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FullName = "Alice", Email = "alice@example.com" },
                new Customer { Id = 2, FullName = "Bob", Email = "bob@example.com" }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(customers);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCustomer()
        {
            var customer = new Customer { Id = 1, FullName = "Alice", Email = "alice@example.com" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(customer);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Alice", result.FullName);
        }

        [Fact]
        public async Task AddAsync_ReturnsCreatedCustomer()
        {
            var customer = new Customer { FullName = "New User", Email = "new@example.com" };
            _mockRepo.Setup(r => r.AddAsync(customer)).ReturnsAsync(customer);

            var result = await _service.AddAsync(customer);

            Assert.Equal("New User", result.FullName);
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