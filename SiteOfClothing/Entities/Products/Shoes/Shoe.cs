using Arch.EntityFrameworkCore.UnitOfWork;
using SiteOfShoes.Entities.Ordering.Cart;
using SiteOfShoes.Entities.ProductTypes.Shoes;
using SiteOfShoes.Models.Products;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SiteOfShoes.Entities.Products.Shoes
{
    public class Shoe : Product
    {
        public virtual List<Cart> Carts { get; set; } = new List<Cart>();


        public Shoe()
        {
        }

        public string Material { get; set; }

        [Required]

        public virtual TypeOfShoe TypeOfShoe { get; set; }

        public int? TypeOfShoeId { get; set; }

        [Required]

        public virtual TypeOfSeason TypeOfSeason { get; set; }

        public int? TypeOfSeasonId { get; set; }

        [Required]
        public virtual TypeOfSex TypeOfSex { get; set; }

        public int? TypeOfSexId { get; set; }

        public virtual TypeOfDestination TypeOfDestination { get; set; }

        public int? TypeOfDestinationId { get; set; }

        public string Color { get; set; }


        public void UpdateByShoeModel(ShoeModel model, IUnitOfWork unityOfWork)
        {
            Name = model.Name;
            isSaled = model.isSaled;
            SalePercent = model.SalePercent;
            Manufacturer = model.Manufacturer;
            Description = model.Description;
            PhotoLink = model.PhotoLink;
            Material = model.Material;
            SizesOfShoe = unityOfWork.GetRepository<SizeOfShoe>().GetAll().Where(t => model.SizesOfShoeIds.Contains(t.Id)).ToList();
            TypeOfDestinationId = model.TypeOfDestinationId;
            TypeOfSeasonId = model.TypeOfSeasonId;
            TypeOfSexId = model.TypeOfSexId;
            TypeOfShoeId = model.TypeOfShoeId;
            TypeOfDestination = model.TypeOfDestination;
            TypeOfSeason = model.TypeOfSeason;
            TypeOfSex = model.TypeOfSex;
            TypeOfShoe = model.TypeOfShoe;
            Color = model.Color;
        }
    }
}
