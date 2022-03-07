using SiteOfShoes.Entities.Accounting;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.ProductTypes.Shoes;
using System.Collections.Generic;

namespace SiteOfShoes.Entities.Ordering.Cart
{
    /// <summary>
    /// Класс - корзина
    /// </summary>
    public class Cart
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public int UserId;

        public virtual List<CartItem> CartItems { get; set; }

        public double GetSum()
        {
            double sum = 0;
            foreach(var item in CartItems)
            {
                sum += item.Product.Costs[item.Product.Costs.Count-1].Cost;
            }
            return sum;
        }

        public void AddCartItem(Shoe shoe)
        {
            CartItems.Add(new CartItem() { Cart = this, CartId = this.Id, Product = shoe, ProductId = shoe.Id});
        }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public Cart(User user)
        {
            User = user;
            UserId = User.ID;
            CartItems = new List<CartItem>();
        }

    }
}
