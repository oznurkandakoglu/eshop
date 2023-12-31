﻿// <auto-generated />
using System;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


#nullable disable

namespace eshop.Migrations
{
    [DbContext(typeof(AkbankDbContext))]
    partial class AkbankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eshop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kırtasiye"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bilgisayar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Astronomi Araçları"
                        });
                });

            modelBuilder.Entity("eshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Beyaz Tahta :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Beyaz Tahta",
                            Price = 570m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Asus Rock :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Asus Rock",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Amatör Teleskop :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Amatör Teleskop",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Beyaz Tahta :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Beyaz Tahta 1",
                            Price = 570m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Beyaz Tahta :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Beyaz Tahta 2",
                            Price = 570m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Beyaz Tahta :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Beyaz Tahta 3",
                            Price = 570m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Beyaz Tahta :)",
                            Discount = 0.20m,
                            ImageUrl = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg",
                            Name = "Beyaz Tahta 4",
                            Price = 570m
                        });
                });

            modelBuilder.Entity("eshop.Models.Product", b =>
                {
                    b.HasOne("eshop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eshop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
