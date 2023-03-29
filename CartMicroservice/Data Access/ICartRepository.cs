

using ProductMicroservice.Models;

namespace CartMicroservice.Data_Access
{
    public interface ICartRepository
    {
        Task<int> AddToCartAsync(int productId, int userId);
        Task<Carts> GetCartAsync(int userId);
        Task<bool> UpdateCartItemAsync(int cartItemId, int quantity);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<bool> CheckoutAsync(int userId);
        Task<bool> ClearCartAsync(int userId);
    }
}
