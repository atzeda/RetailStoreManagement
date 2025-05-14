using System.Collections.Generic;
using System.Threading.Tasks;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int id);
        Task<Purchase> AddAsync(Purchase purchase);
    }
}