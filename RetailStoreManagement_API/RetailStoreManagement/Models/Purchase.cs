using System;
using System.Collections.Generic;

namespace RetailStoreManagement.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public List<PurchaseItem> Items { get; set; } = new();
    }
}