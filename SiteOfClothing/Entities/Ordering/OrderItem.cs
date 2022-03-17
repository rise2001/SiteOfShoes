

using SiteOfShoes.Entities.Products;
using SiteOfShoes.Entities.ProductTypes.Shoes;

namespace SiteOfShoes.Entities.Ordering
{
    public class OrderItem
    {
        public int Id { get; set; }
        /// <summary>
        /// Получает или задает Продукт в заказе
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Получает или задает заказ
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Получает или задает ID заказа
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// Получает или задает размер товара
        /// </summary>
        public virtual SizeOfShoe SizeOfProduct { get; set; }

        /// <summary>
        /// Получает или задает Id размера товара
        /// </summary>
        public int? SizeOfProductId { get; set; }
        /// <summary>
        /// Получает или задает цену
        /// </summary>
        public double? Cost { get; set; }
    }
}
