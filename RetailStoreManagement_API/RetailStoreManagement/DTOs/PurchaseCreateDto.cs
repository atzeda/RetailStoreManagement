using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailStoreManagement.DTOs
{
    public class PurchaseCreateDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<PurchaseItemDto> Items { get; set; }
    }

    public class PurchaseItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}