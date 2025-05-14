using System.ComponentModel.DataAnnotations;

namespace RetailStoreManagement.DTOs
{
    public class CustomerCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}