﻿namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public Decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart() { }

    }
}
