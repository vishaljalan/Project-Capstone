using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }

       
        public int Price { get; set; }

        

        public string ImageName { get; set; }


        [ForeignKey("CategoryId")]
        public ProductsCategory? Category { get; set; }
    }
}
