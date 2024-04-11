﻿// <auto-generated />
using System;
using Group5_DBApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Group5_DBApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Group5_DBApp.Models.CreditCards", b =>
                {
                    b.Property<decimal>("card_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("card_number")
                        .HasColumnType("TEXT");

                    b.Property<string>("expire_date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("user_id")
                        .HasColumnType("TEXT");

                    b.HasKey("card_id");

                    b.ToTable("CreditCards");

                    b.HasData(
                        new
                        {
                            card_id = 1m,
                            card_number = "1234123412341234",
                            expire_date = "2025-12-31",
                            user_id = 1m
                        },
                        new
                        {
                            card_id = 2m,
                            card_number = "5678567856785678",
                            expire_date = "2025-01-31",
                            user_id = 2m
                        });
                });

            modelBuilder.Entity("Group5_DBApp.Models.Orders", b =>
                {
                    b.Property<decimal>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("credit_card")
                        .HasColumnType("TEXT");

                    b.Property<string>("delivery_date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("delivery_price")
                        .HasColumnType("TEXT");

                    b.Property<string>("delivery_type")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("prod_id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("quantity")
                        .HasColumnType("TEXT");

                    b.Property<string>("ship_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("status")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("user_id")
                        .HasColumnType("TEXT");

                    b.HasKey("order_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Group5_DBApp.Models.Product", b =>
                {
                    b.Property<decimal>("prod_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<string>("prod_name")
                        .HasColumnType("TEXT");

                    b.HasKey("prod_id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            prod_id = 1m,
                            price = 59.99m,
                            prod_name = "Wilson Evolution Indoor Basketball"
                        },
                        new
                        {
                            prod_id = 2m,
                            price = 29.99m,
                            prod_name = "Spalding NBA Street Outdoor Basketball"
                        },
                        new
                        {
                            prod_id = 3m,
                            price = 89.99m,
                            prod_name = "Nike Elite Championship Basketball"
                        },
                        new
                        {
                            prod_id = 4m,
                            price = 39.99m,
                            prod_name = "Under Armour 495 Indoor/Outdoor Basketball"
                        },
                        new
                        {
                            prod_id = 5m,
                            price = 44.99m,
                            prod_name = "Molten BGG Composite Basketball"
                        });
                });

            modelBuilder.Entity("Group5_DBApp.Models.Stock", b =>
                {
                    b.Property<decimal>("stock_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("prod_id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("quantity")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("warehouse_id")
                        .HasColumnType("TEXT");

                    b.HasKey("stock_id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Group5_DBApp.Models.Suppliers", b =>
                {
                    b.Property<decimal>("sup_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("prod_id")
                        .HasColumnType("TEXT");

                    b.HasKey("sup_id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Group5_DBApp.Models.Users", b =>
                {
                    b.Property<decimal>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("delivery_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("home_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("job_title")
                        .HasColumnType("TEXT");

                    b.Property<string>("payment_address")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("salary")
                        .HasColumnType("TEXT");

                    b.Property<string>("user_type")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("user_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            user_id = 1m,
                            user_type = "Customer",
                            username = "John Doe"
                        },
                        new
                        {
                            user_id = 2m,
                            user_type = "Staff",
                            username = "Dan Johnson"
                        });
                });

            modelBuilder.Entity("Group5_DBApp.Models.Warehouse", b =>
                {
                    b.Property<decimal>("warehouse_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("address")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("capacity")
                        .HasColumnType("TEXT");

                    b.HasKey("warehouse_id");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            warehouse_id = 1m,
                            address = "123 Main Street",
                            capacity = 100m
                        },
                        new
                        {
                            warehouse_id = 2m,
                            address = "456 Elm Avenue",
                            capacity = 75m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
