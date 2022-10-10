using System.ComponentModel.DataAnnotations;

namespace shop.CoreBusiness
{
    public class Products
    {

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public double Price { get; set; }

        public double? Sum { get; set; }

        

    }
}