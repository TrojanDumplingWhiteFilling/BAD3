using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<BatchStock>? BatchStocks { get; set; }

        // reference to StockAllergen added
        public ICollection<StockAllergen>? StockAllergens { get; set; }
    }
}
