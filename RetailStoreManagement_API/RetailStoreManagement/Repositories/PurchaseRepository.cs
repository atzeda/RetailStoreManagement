using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailStoreManagement.Data;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly StoreContext _context;
        public PurchaseRepository(StoreContext context) => _context = context;

        public async Task<IEnumerable<Purchase>> GetAllAsync() =>
            await _context.Purchases
                .Include(p => p.Customer)
                .Include(p => p.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();

        public async Task<Purchase> GetByIdAsync(int id) =>
            await _context.Purchases
                .Include(p => p.Customer)
                .Include(p => p.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Purchase> AddAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }
    }
}