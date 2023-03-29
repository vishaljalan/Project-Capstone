using ProductMicroservice.Data_Access;
using ProductMicroservice.Models;
using ProductMicroservice.Models.dto;

namespace ProductMicroservice.Repository
{
    public class ProductsRepository : Iproduct
    {
        private readonly CapstoneDbContext _dbContext;

        public ProductsRepository(CapstoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string addNewProduct(Productdto product)
        {   
            Products product1 = new Products();
            product1.Name = product.Name;
            product1.Description = product.Description;
            product1.Price = product.Price;
            product1.CategoryId = product.CategoryId;
            product1.ImageName = product.ImageName;

            try
            {
                _dbContext.Products.Add(product1);
                _dbContext.SaveChanges();
                

            }catch(Exception ex)
            {
                throw new Exception("unable to add products due to:"+ ex.Message);
            }

            return "Added";
        }

        public string deleteProduct(int productId)
        {
            try
            {
                var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw new Exception("unable to delete product due to:" + ex.Message);
            }

            return "deleted";
        }

        public List<Products> getAllProducts()
        {
            try
            {
                return _dbContext.Products.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("unable to fetch products due to:" + ex.Message);
            }
        }

        public Products getProductById(int productId)
        {
            try
            {
                var product =  _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("unable to fetch product due to:" + ex.Message);
            }

        }

        public List<Products> getProductsByCategory(int id)
        {
            try
            {   
                var products = _dbContext.Products.Where(x=>x.CategoryId==id).ToList();
                return products;

            }
            catch (Exception ex)
            {
                throw new Exception("unable to fetch product due to:" + ex.Message);
            }
        }

        public string updateProduct(Productdto product)
        {   Products products = new Products();
            products.ProductId = product.ProductId;
            products.CategoryId = product.CategoryId;
            products.ImageName = product.ImageName;
            products.Description = product.Description;
            products.Price = product.Price;
            
            try
            {
                var findproduct = _dbContext.Products.Find(products.ProductId);
                if (findproduct != null)
                {
                    findproduct.Name = product.Name;
                    findproduct.Description = product.Description;
                    findproduct.CategoryId = product.CategoryId;
                    findproduct.Price = product.Price;
                    
                    findproduct.ImageName = product.ImageName;

                    _dbContext.SaveChanges();
                    return "Updated Boss";
                }

                return "Unable to find the product with id:" + product.ProductId;

            }
            catch (Exception ex)
            {
                throw new Exception("unable to update product due to:" + ex.Message);
            }
        }
    }
}
