namespace ProductMicroservice.Models.dto
{
    public class Productdto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }


        public int Price { get; set; }

        public string ImageName { get; set; }
    }
}
