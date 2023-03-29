using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductMicroservice.Models
{
    public class Carts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int TotalPrice { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }

        // Add this property to establish the relationship with CartItems
        public ICollection<CartItems> CartItems { get; set; }
    }
}
