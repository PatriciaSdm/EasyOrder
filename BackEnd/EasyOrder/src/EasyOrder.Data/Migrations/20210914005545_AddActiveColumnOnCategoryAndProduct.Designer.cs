﻿// <auto-generated />
using System;
using EasyOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyOrder.Data.Migrations
{
    [DbContext(typeof(EasyOrderContext))]
    [Migration("20210914005545_AddActiveColumnOnCategoryAndProduct")]
    partial class AddActiveColumnOnCategoryAndProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryExtra", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExtrasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ExtrasId");

                    b.HasIndex("ExtrasId");

                    b.ToTable("CategoriesExtras");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Extra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrder")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Table")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ExtraItem", b =>
                {
                    b.Property<Guid>("ExtrasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExtrasId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("ItemsExtras");
                });

            modelBuilder.Entity("CategoryExtra", b =>
                {
                    b.HasOne("EasyOrder.Business.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .IsRequired();

                    b.HasOne("EasyOrder.Business.Models.Extra", null)
                        .WithMany()
                        .HasForeignKey("ExtrasId")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Item", b =>
                {
                    b.HasOne("EasyOrder.Business.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("IdOrder")
                        .IsRequired();

                    b.HasOne("EasyOrder.Business.Models.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("IdProduct")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Product", b =>
                {
                    b.HasOne("EasyOrder.Business.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ExtraItem", b =>
                {
                    b.HasOne("EasyOrder.Business.Models.Extra", null)
                        .WithMany()
                        .HasForeignKey("ExtrasId")
                        .IsRequired();

                    b.HasOne("EasyOrder.Business.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("EasyOrder.Business.Models.Product", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
