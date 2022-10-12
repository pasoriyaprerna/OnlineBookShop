namespace Book_Shopping_Cart.API.Entities
{
    public class BookShoppingCart
    {
        public string UserName { get; set; }
        public List<BookShoppingCartItem> Items { get; set; } = new List<BookShoppingCartItem>();

        public BookShoppingCart()
        {
        }

        public BookShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
