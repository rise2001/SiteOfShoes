using SiteOfShoes.Entities.Accounting;
using SiteOfShoes.Entities.Products;
using System.Collections.Generic;

namespace SiteOfShoes.Entities.Ordering
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public int Id { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

        public virtual User User { get; set; }

        public int? UserId { get; set; }

        public double? Cost { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public int? OrderStatusId;
    }
}
