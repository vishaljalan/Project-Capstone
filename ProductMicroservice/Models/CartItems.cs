using ProductMicroservice.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Models
{
    public class CartItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("CartId")]
        public Carts Carts { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
