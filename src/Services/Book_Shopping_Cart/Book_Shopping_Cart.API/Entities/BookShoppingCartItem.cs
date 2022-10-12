namespace Book_Shopping_Cart.API.Entities
{
    public class BookShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BookId { get; set; }
        public string BookName { get; set; }
    }
}
