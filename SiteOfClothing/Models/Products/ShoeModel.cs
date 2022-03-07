using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteOfShoes.Entities.Products;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.ProductTypes.Shoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SiteOfShoes.Models.Products
{
    public class ShoeModel
    {
        public int[] SizesOfShoeIds { get; set; }


        public List<SizeOfShoe> SizesOfShoe { get; set; }


        public ShoeModel()
        {
        }

        public ShoeModel(Shoe shoe)
        {
            Id = shoe.Id;
            Name = shoe.Name;
            isSaled = shoe.isSaled;
            SalePercent = shoe.SalePercent;
            Manufacturer = shoe.Manufacturer;
            Material = shoe.Material;
            Description = shoe.Description;
            PhotoLink = shoe.PhotoLink;
            TypeOfSeason = shoe.TypeOfSeason;
            TypeOfSex = shoe.TypeOfSex;
            TypeOfDestination = shoe.TypeOfDestination;
            TypeOfShoe = shoe.TypeOfShoe;
            TypeOfSeasonId = shoe.TypeOfSeasonId;
            TypeOfSexId = shoe.TypeOfSexId;
            TypeOfDestinationId = shoe.TypeOfDestinationId;
            TypeOfShoeId = shoe.TypeOfShoeId;
            SizesOfShoe = shoe.SizesOfShoe;
            SizesOfShoeIds = SizesOfShoe.Select(t => t.Id).ToArray();
            Color = shoe.Color;
            Cost = shoe.Costs.Last().Cost;
        }

        public ShoeModel(Shoe shoe, double cost)
        {
            Id = shoe.Id;
            Name = shoe.Name;
            isSaled = shoe.isSaled;
            SalePercent = shoe.SalePercent;
            Manufacturer = shoe.Manufacturer;
            Material = shoe.Material;
            Description = shoe.Description;
            PhotoLink = shoe.PhotoLink;
            TypeOfSeason = shoe.TypeOfSeason;
            TypeOfSex = shoe.TypeOfSex;
            TypeOfDestination = shoe.TypeOfDestination;
            Color = shoe.Color;
            Cost = cost;
            
        }

        /// <summary>
        /// Получает или задает Название продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает Название продукта
        /// </summary>
        [Required(ErrorMessage ="Введите название")]
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
        /// Получает или задает Цену продукта
        /// </summary>
        [Required(ErrorMessage ="Введите цену")]

        public double Cost { get; set; }

        /// <summary>
        /// Получает или задает Производителя продукта
        /// </summary>
        [Required(ErrorMessage = "Введите производителя")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Получает или задает Описание продукта
        /// </summary>
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        /// <summary>
        /// Получает или задает Ссылку на фото продукта
        /// </summary>
        [Required(ErrorMessage = "Вставьте ссылку на фото")]
        public string PhotoLink { get; set; }

        /// <summary>
        /// Получанет или задает материал
        /// </summary>
        [Required(ErrorMessage = "Введите материал")]
        public string Material { get; set; }

        /// <summary>
        /// Получает или задает сезонность одежды
        /// </summary>
        [Required(ErrorMessage = "Выберите сезонность")]
        public TypeOfSeason TypeOfSeason { get; set; }

        public int? TypeOfSeasonId { get; set; }

        [Required(ErrorMessage = "Выберите пол")]
        public TypeOfSex TypeOfSex { get; set; }

        public int? TypeOfSexId { get; set; }

        public TypeOfDestination TypeOfDestination { get; set; }

        public int? TypeOfDestinationId { get; set; }

        [Required(ErrorMessage = "Выберите тип обуви")]
        public TypeOfShoe TypeOfShoe { get; set; }

        public int? TypeOfShoeId { get; set; }

        [Required(ErrorMessage = "Выберите цвет")]
        public string Color { get; set; }

        public Shoe GetShoe(IUnitOfWork unitOfWork)
        {
            return new Shoe()
            {
                Name = this.Name,
                isSaled = this.isSaled,
                SalePercent = this.SalePercent,
                Manufacturer = this.Manufacturer,
                Description = this.Description,
                PhotoLink = this.PhotoLink,
                Material = this.Material,
                SizesOfShoe = unitOfWork.GetRepository<SizeOfShoe>().GetAll().Where(t => SizesOfShoeIds.Contains(t.Id)).ToList(),
                TypeOfDestinationId = this.TypeOfDestinationId,
                TypeOfSeasonId = this.TypeOfSeasonId,
                TypeOfSexId = this.TypeOfSexId,
                TypeOfShoeId = this.TypeOfShoeId,
                TypeOfDestination = this.TypeOfDestination,
                TypeOfSeason = this.TypeOfSeason,
                TypeOfSex = this.TypeOfSex,
                TypeOfShoe = this.TypeOfShoe,
                Color = this.Color
            };
        }

        public static IEnumerable<ShoeModel> CreateShoeModels(IQueryable<Shoe> shoes)
        {
            List<ShoeModel> models = new List<ShoeModel>();
            foreach(var item in shoes)
            {
                models.Add(new ShoeModel(item));
            }
            return models;
        }
    }
}
