using System.ComponentModel.DataAnnotations;

namespace RetailStoreManagement.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }

    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}