﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Data.EF.Contexts;

namespace SiteOfShoes.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20211226192407_FixEntities")]
    partial class FixEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ShoeSizeOfShoe", b =>
                {
                    b.Property<int>("ShoesId")
                        .HasColumnType("int");

                    b.Property<int>("SizesOfShoeId")
                        .HasColumnType("int");

                    b.HasKey("ShoesId", "SizesOfShoeId");

                    b.HasIndex("SizesOfShoeId");

                    b.ToTable("ShoeSizeOfShoe");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Accounting.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Accounting.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("Email");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "admin@ya.ru",
                            Name = "Admin",
                            Password = "admin",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("SiteOfShoes.Entities.ProductTypes.Shoes.SizeOfShoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SizesOfShoe");

                    b.HasData(
                        new
                        {
                            Id = 17,
                            Name = "17"
                        },
                        new
                        {
                            Id = 18,
                            Name = "18"
                        },
                        new
                        {
                            Id = 19,
                            Name = "19"
                        },
                        new
                        {
                            Id = 20,
                            Name = "20"
                        },
                        new
                        {
                            Id = 21,
                            Name = "21"
                        },
                        new
                        {
                            Id = 22,
                            Name = "22"
                        },
                        new
                        {
                            Id = 23,
                            Name = "23"
                        },
                        new
                        {
                            Id = 24,
                            Name = "24"
                        },
                        new
                        {
                            Id = 25,
                            Name = "25"
                        },
                        new
                        {
                            Id = 26,
                            Name = "26"
                        },
                        new
                        {
                            Id = 27,
                            Name = "27"
                        },
                        new
                        {
                            Id = 28,
                            Name = "28"
                        },
                        new
                        {
                            Id = 29,
                            Name = "29"
                        },
                        new
                        {
                            Id = 30,
                            Name = "30"
                        },
                        new
                        {
                            Id = 31,
                            Name = "31"
                        },
                        new
                        {
                            Id = 32,
                            Name = "32"
                        },
                        new
                        {
                            Id = 33,
                            Name = "33"
                        },
                        new
                        {
                            Id = 34,
                            Name = "34"
                        },
                        new
                        {
                            Id = 35,
                            Name = "35"
                        },
                        new
                        {
                            Id = 36,
                            Name = "36"
                        },
                        new
                        {
                            Id = 37,
                            Name = "37"
                        },
                        new
                        {
                            Id = 38,
                            Name = "38"
                        },
                        new
                        {
                            Id = 39,
                            Name = "39"
                        },
                        new
                        {
                            Id = 40,
                            Name = "40"
                        },
                        new
                        {
                            Id = 41,
                            Name = "41"
                        },
                        new
                        {
                            Id = 42,
                            Name = "42"
                        },
                        new
                        {
                            Id = 43,
                            Name = "43"
                        },
                        new
                        {
                            Id = 44,
                            Name = "44"
                        },
                        new
                        {
                            Id = 45,
                            Name = "45"
                        },
                        new
                        {
                            Id = 46,
                            Name = "46"
                        },
                        new
                        {
                            Id = 47,
                            Name = "47"
                        },
                        new
                        {
                            Id = 48,
                            Name = "48"
                        },
                        new
                        {
                            Id = 49,
                            Name = "49"
                        },
                        new
                        {
                            Id = 50,
                            Name = "50"
                        },
                        new
                        {
                            Id = 51,
                            Name = "51"
                        },
                        new
                        {
                            Id = 52,
                            Name = "52"
                        },
                        new
                        {
                            Id = 53,
                            Name = "53"
                        },
                        new
                        {
                            Id = 54,
                            Name = "54"
                        },
                        new
                        {
                            Id = 55,
                            Name = "55"
                        },
                        new
                        {
                            Id = 56,
                            Name = "56"
                        },
                        new
                        {
                            Id = 57,
                            Name = "57"
                        },
                        new
                        {
                            Id = 58,
                            Name = "58"
                        },
                        new
                        {
                            Id = 59,
                            Name = "59"
                        },
                        new
                        {
                            Id = 60,
                            Name = "60"
                        });
                });

            modelBuilder.Entity("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfDestination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfDestination");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfSeason");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Зимняя"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Летняя"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Осенняя"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Весенняя"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Всесезонная"
                        });
                });

            modelBuilder.Entity("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfSex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfSex");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Мужской"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Женский"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Унисекс"
                        });
                });

            modelBuilder.Entity("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfShoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfShoe");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Products.CostOfProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfCost")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CostOfProducts");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isSaled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Products.Shoes.Shoe", b =>
                {
                    b.HasBaseType("SiteOfShoes.Entities.Products.Product");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfDestinationId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfSexId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfShoeId")
                        .HasColumnType("int");

                    b.HasIndex("TypeOfDestinationId");

                    b.HasIndex("TypeOfSeasonId");

                    b.HasIndex("TypeOfSexId");

                    b.HasIndex("TypeOfShoeId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("ShoeSizeOfShoe", b =>
                {
                    b.HasOne("SiteOfShoes.Entities.Products.Shoes.Shoe", null)
                        .WithMany()
                        .HasForeignKey("ShoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteOfShoes.Entities.ProductTypes.Shoes.SizeOfShoe", null)
                        .WithMany()
                        .HasForeignKey("SizesOfShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Accounting.User", b =>
                {
                    b.HasOne("SiteOfShoes.Entities.Accounting.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Products.CostOfProduct", b =>
                {
                    b.HasOne("SiteOfShoes.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SiteOfShoes.Entities.Products.Shoes.Shoe", b =>
                {
                    b.HasOne("SiteOfShoes.Entities.Products.Product", null)
                        .WithOne()
                        .HasForeignKey("SiteOfShoes.Entities.Products.Shoes.Shoe", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfDestination", "TypeOfDestination")
                        .WithMany()
                        .HasForeignKey("TypeOfDestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfSeason", "TypeOfSeason")
                        .WithMany()
                        .HasForeignKey("TypeOfSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfSex", "TypeOfSex")
                        .WithMany()
                        .HasForeignKey("TypeOfSexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteOfShoes.Entities.ProductTypes.Shoes.TypeOfShoe", "TypeOfShoe")
                        .WithMany()
                        .HasForeignKey("TypeOfShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfDestination");

                    b.Navigation("TypeOfSeason");

                    b.Navigation("TypeOfSex");

                    b.Navigation("TypeOfShoe");
                });
#pragma warning restore 612, 618
        }
    }
}
