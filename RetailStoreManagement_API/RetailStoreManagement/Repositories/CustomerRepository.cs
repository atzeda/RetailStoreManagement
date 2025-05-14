using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailStoreManagement.Data;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext _context;
        public CustomerRepository(StoreContext context) => _context = context;

        public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();
        public async Task<Customer> GetByIdAsync(int id) => await _context.Customers.FindAsync(id);
        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}