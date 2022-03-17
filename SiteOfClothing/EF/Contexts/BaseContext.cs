using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SiteOfShoes.Entities.Accounting;
using SiteOfShoes.Entities.Ordering;
using SiteOfShoes.Entities.Ordering.Cart;
using SiteOfShoes.Entities.Products;
using SiteOfShoes.Entities.Products.Shoes;
using SiteOfShoes.Entities.ProductTypes.Shoes;

namespace Data.EF.Contexts
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
               : base(options)
        { }
        #region DbSets
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeOfSex> TypesOfSex { get; set; }
        public DbSet<TypeOfDestination> TypesOfDestination { get; set; }
        public DbSet<TypeOfSeason> TypesOfSeason { get; set; }
        public DbSet<TypeOfShoe> TypesOfShoe { get; set; }
        public DbSet<SizeOfShoe> SizesOfShoe { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<CostOfProduct> CostOfProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles").HasData(
                new Role() { ID = 1, Name = "Admin" },
                new Role() { ID = 2, Name = "User" }
                );
            modelBuilder.Entity<User>().ToTable("Users").HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().HasData(
                new User() { ID = 1, Name = "Admin", RoleId = 1, Email = "admin@ya.ru", Password = "admin" }
                );
            modelBuilder.Entity<TypeOfSex>().ToTable("TypesOfSex").HasData(
                new TypeOfSex() { Id = 1, Name = "Мужской" },
                new TypeOfSex() { Id = 2, Name = "Женский" },
                new TypeOfSex() { Id = 3, Name = "Унисекс" }
                );
            modelBuilder.Entity<TypeOfShoe>().ToTable("TypesOfShoe");
            modelBuilder.Entity<TypeOfDestination>().ToTable("TypesOfDestination");
            modelBuilder.Entity<TypeOfSeason>().ToTable("TypesOfSeason").HasData(
                new TypeOfSex() { Id = 1, Name = "Зимняя" },
                new TypeOfSex() { Id = 2, Name = "Летняя" },
                new TypeOfSex() { Id = 3, Name = "Осенняя" },
                new TypeOfSex() { Id = 4, Name = "Весенняя" },
                new TypeOfSex() { Id = 5, Name = "Всесезонная" }
                );
            modelBuilder.Entity<SizeOfShoe>().ToTable("SizesOfShoe");
            for (int i = 17; i <= 60; i++)
                modelBuilder.Entity<SizeOfShoe>().HasData(new SizeOfShoe() { Id = i, Name = i.ToString() });
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Shoe>().ToTable("Shoes");
            modelBuilder.Entity<CostOfProduct>().ToTable("CostOfProducts");
            modelBuilder.Entity<Cart>().ToTable("Carts");
            modelBuilder.Entity<CartItem>().ToTable("CartItems");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");

            modelBuilder.Entity<OrderStatus>().ToTable("OrderStatuses").HasData(
                new OrderStatus() { Id = 1, Name = "Новый" },
                new OrderStatus() { Id = 2, Name = "В обработке" },
                new OrderStatus() { Id = 3, Name = "В доставке" },
                new OrderStatus() { Id = 4, Name = "Доставлен" }
                );
        }


        public static BaseContext GetBaseContext()
            => new BaseContext(new DbContextOptions<BaseContext>());


    }
}