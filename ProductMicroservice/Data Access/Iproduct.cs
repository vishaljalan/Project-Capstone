using ProductMicroservice.Models;
using ProductMicroservice.Models.dto;

namespace ProductMicroservice.Data_Access
{
    public interface Iproduct
    {
        public List<Products> getAllProducts();

        public string addNewProduct(Productdto product);

        public string deleteProduct(int productId);

        public string updateProduct(Productdto product);

        public Products getProductById(int productId);

        public List<Products> getProductsByCategory(int id);



    }
}
