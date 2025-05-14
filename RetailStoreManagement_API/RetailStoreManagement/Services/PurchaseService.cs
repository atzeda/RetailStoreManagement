using System.Collections.Generic;
using System.Threading.Tasks;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        public PurchaseService(IPurchaseRepository repository) => _repository = repository;

        public Task<IEnumerable<Purchase>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Purchase> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<Purchase> AddAsync(Purchase purchase) => _repository.AddAsync(purchase);
    }
}