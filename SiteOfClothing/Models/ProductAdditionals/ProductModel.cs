using SiteOfShoes.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBox.Models.ProductAdditionals
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public bool IsBuyed { get; set; }
    }
}
