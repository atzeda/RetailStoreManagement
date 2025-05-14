using System;
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
    public class PurchaseServiceTests
    {
        private readonly Mock<IPurchaseRepository> _mockRepo;
        private readonly PurchaseService _service;

        public PurchaseServiceTests()
        {
            _mockRepo = new Mock<IPurchaseRepository>();
            _service = new PurchaseService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsPurchases()
        {
            var purchases = new List<Purchase>
            {
                new Purchase { Id = 1, CustomerId = 1, PurchaseDate = DateTime.UtcNow },
                new Purchase { Id = 2, CustomerId = 2, PurchaseDate = DateTime.UtcNow }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(purchases);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsPurchase()
        {
            var purchase = new Purchase { Id = 1, CustomerId = 1, PurchaseDate = DateTime.UtcNow };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(purchase);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.CustomerId);
        }

        [Fact]
        public async Task AddAsync_ReturnsCreatedPurchase()
        {
            var purchase = new Purchase { CustomerId = 1, PurchaseDate = DateTime.UtcNow };
            _mockRepo.Setup(r => r.AddAsync(purchase)).ReturnsAsync(purchase);

            var result = await _service.AddAsync(purchase);

            Assert.Equal(1, result.CustomerId);
        }
    }
}