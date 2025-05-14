using System.Linq;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any()) return;

            var products = new[]
            {
                new Product { Name = "Keyboard", Price = 50, Stock = 20 },
                new Product { Name = "Mouse", Price = 30, Stock = 50 },
                new Product { Name = "Monitor", Price = 200, Stock = 10 }
            };
            context.Products.AddRange(products);

            var customers = new[]
            {
                new Customer { FullName = "Alice Johnson", Email = "alice@example.com" },
                new Customer { FullName = "Bob Smith", Email = "bob@example.com" }
            };
            context.Customers.AddRange(customers);

            context.SaveChanges();
        }
    }
}