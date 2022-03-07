using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteOfShoes.Entities.Products
{
    public class Product
    {
        public virtual List<CostOfProduct> Costs { get; set; } = new List<CostOfProduct>(); // Цены на товар    

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает Название продукта
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает Распродажа ли продукта
        /// </summary>
        public bool isSaled { get; set; } = false;

        /// <summary>
        /// Получает или задает Процент скидки
        /// </summary>
        public double SalePercent { get; set; } = 0;

        /// <summary>
        /// Получает или задает Производителя продукта
        /// </summary>
        [Required]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Получает или задает Описание продукта
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Получает или задает Ссылку на фото продукта
        /// </summary>
        [Required]
        public string PhotoLink { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
