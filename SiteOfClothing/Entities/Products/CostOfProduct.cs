
using SiteOfShoes.Entities.Products.Shoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteOfShoes.Entities.Products
{
    public class CostOfProduct
    {
        public CostOfProduct(Product product, double cost)
        {
            Product = product;
            ProductId = product.Id;
            Cost = cost;
        }

        public CostOfProduct()
        {

        }

        /// <summary>
        /// Получает или задает Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает Продукт
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Получает или задает Время стоимости продукта
        /// </summary>
        public DateTime TimeOfCost { get; set; } = DateTime.Now;

        /// <summary>
        /// Получает или задает Цену продукта
        /// </summary>
        public double Cost { get; set; }
    }
}
