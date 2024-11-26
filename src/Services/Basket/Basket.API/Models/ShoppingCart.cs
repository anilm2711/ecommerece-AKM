namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();

        public Decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string UserName)
        {
            this.UserName = UserName;
        }
        public ShoppingCart() { }

    }
}
