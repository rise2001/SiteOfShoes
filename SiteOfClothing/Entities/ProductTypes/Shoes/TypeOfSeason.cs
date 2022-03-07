using SiteOfShoes.Entities.Products.Shoes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteOfShoes.Entities.ProductTypes.Shoes
{
    public class TypeOfSeason
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
