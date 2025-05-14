using System.Collections.Generic;
using System.Threading.Tasks;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}