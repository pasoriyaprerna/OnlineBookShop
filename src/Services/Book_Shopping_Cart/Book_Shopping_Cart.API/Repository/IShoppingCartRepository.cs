using Book_Shopping_Cart.API.Entities;

namespace Book_Shopping_Cart.API.Repository
{
    public interface IShoppingCartRepository 
    {
        Task<BookShoppingCart> GetCart(string userName);
        Task<BookShoppingCart> UpdateCart(BookShoppingCart basket);
        Task DeleteCart(string userName);
    }
}
