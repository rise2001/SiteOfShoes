using SiteOfShoes.Entities.Products;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.ProductTypes.Shoes;

namespace SiteOfShoes.Entities.Ordering.Cart
{
    public class CartItem
    {
        public int Id { get; set; }

        public virtual Shoe Product { get; set; }

        public int ProductId { get; set; }

        public virtual Cart Cart { get; set; }

        public int CartId { get; set; }
        
        public virtual SizeOfShoe SizeOfProduct { get; set; }
        
        public int? SizeOfProductId { get; set; }

        public int SizeOfShoeId { get; set; } = -1;
    }
}
