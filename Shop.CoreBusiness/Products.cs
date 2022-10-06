using System.ComponentModel.DataAnnotations;

namespace Shop.CoreBusiness
{
    public class Products
    {

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        public double Price { get; set; }

        

    }
}