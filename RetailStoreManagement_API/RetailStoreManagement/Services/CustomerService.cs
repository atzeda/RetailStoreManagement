using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public Task<IEnumerable<Customer>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Customer> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<Customer> AddAsync(Customer customer) => _repository.AddAsync(customer);
        public Task UpdateAsync(Customer customer) => _repository.UpdateAsync(customer);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}