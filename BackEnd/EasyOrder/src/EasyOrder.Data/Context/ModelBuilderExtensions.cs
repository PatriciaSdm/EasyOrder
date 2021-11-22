using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //ADD CATEGORY
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("36320cd1-6cce-42b0-8940-02c887431a57"),
                    Name = "Pasteis",
                    Active = true
                },
                new Category
                {
                    Id = Guid.Parse("dccbc2dd-1621-4654-b3f8-74fc917cbd41"),
                    Name = "Pizza",
                    Active = true
                },
                new Category
                {
                    Id = Guid.Parse("3c9e8004-f3f6-49d2-8568-deb44f3fb267"),
                    Name = "Burguers",
                    Active = true
                }
            );

            //ADD EXTRA
            modelBuilder.Entity<Extra>().HasData(
                new Extra
                {
                    Id = Guid.Parse("53634a9a-7ebd-48af-979f-b08bf7d0e217"),
                    Name = "Queijo",
                    Active = true
                },
                new Extra
                {
                    Id = Guid.Parse("265f34a4-1535-449b-acdf-6730c4443e73"),
                    Name = "Bacon",
                    Active = true
                },
                new Extra
                {
                    Id = Guid.Parse("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"),
                    Name = "Orégano",
                    Active = true
                }
            );

            //ADD CATEGORYEXTRA
            modelBuilder.Entity<CategoryExtra>().HasData(
                new CategoryExtra
                {
                    IdCategory = Guid.Parse("36320cd1-6cce-42b0-8940-02c887431a57"),
                    IdExtra = Guid.Parse("53634a9a-7ebd-48af-979f-b08bf7d0e217")
                },
                new CategoryExtra
                {
                    IdCategory = Guid.Parse("dccbc2dd-1621-4654-b3f8-74fc917cbd41"),
                    IdExtra = Guid.Parse("53634a9a-7ebd-48af-979f-b08bf7d0e217")
                },
                new CategoryExtra
                {
                    IdCategory = Guid.Parse("36320cd1-6cce-42b0-8940-02c887431a57"),
                    IdExtra = Guid.Parse("265f34a4-1535-449b-acdf-6730c4443e73")
                },
                new CategoryExtra
                {
                    IdCategory = Guid.Parse("3c9e8004-f3f6-49d2-8568-deb44f3fb267"),
                    IdExtra = Guid.Parse("265f34a4-1535-449b-acdf-6730c4443e73")
                },
                new CategoryExtra
                {
                    IdCategory = Guid.Parse("dccbc2dd-1621-4654-b3f8-74fc917cbd41"),
                    IdExtra = Guid.Parse("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c")
                }
            );

            //ADD PRODUCT
            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = Guid.Parse("7c378c3b-b5f5-4ee3-8f1d-5ff73a89b7c1"),
                  Name = "Pastel de carne",
                  Description = "Pastel de carne muito gostoso",
                  Price = 10,
                  IdCategory = Guid.Parse("36320cd1-6cce-42b0-8940-02c887431a57"),
                  Active = true
              },
              new Product
              {
                  Id = Guid.Parse("3e8d9a71-0bbd-425f-bcc5-fb36048ef62c"),
                  Name = "Pastel de queijo",
                  Description = "Pastel de quejo muito gostoso",
                  Price = 15,
                  IdCategory = Guid.Parse("36320cd1-6cce-42b0-8940-02c887431a57"),
                  Active = true
              },
              new Product
              {
                  Id = Guid.Parse("eef85ecb-c7ff-46c6-89a8-345ab93669a6"),
                  Name = "Pizza",
                  Description = "Pizza muito gostoso",
                  Price = 45,
                  IdCategory = Guid.Parse("dccbc2dd-1621-4654-b3f8-74fc917cbd41"),
                  Active = true
              });

            ////ADD ORDER
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"),
                    Name = "Snow",
                    Table = 1
                },
                new Order
                {
                    Id = Guid.Parse("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"),
                    Name = "Salem",
                    Table = 2
                });

            ////ADD ITEM
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = Guid.Parse("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"),
                    IdProduct = Guid.Parse("7c378c3b-b5f5-4ee3-8f1d-5ff73a89b7c1"),
                    IdOrder = Guid.Parse("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"),
                    Quantity = 2
                },
                new Item
                {
                    Id = Guid.Parse("2aea14eb-dd41-4ce6-ba90-ad3a82553e25"),
                    IdProduct = Guid.Parse("3e8d9a71-0bbd-425f-bcc5-fb36048ef62c"),
                    IdOrder = Guid.Parse("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"),
                    Quantity = 2
                },
                new Item
                {
                    Id = Guid.Parse("b9d81522-7e29-47b1-bc63-b80fa6241872"),
                    IdProduct = Guid.Parse("eef85ecb-c7ff-46c6-89a8-345ab93669a6"),
                    IdOrder = Guid.Parse("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"),
                    Quantity = 2
                }
             );

            //ADD ITEMEXTRA
            modelBuilder.Entity<ItemExtra>().HasData(
                new ItemExtra
                {
                    IdExtra = Guid.Parse("53634a9a-7ebd-48af-979f-b08bf7d0e217"),
                    IdItem = Guid.Parse("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb")
                },
                new ItemExtra
                {
                    IdExtra = Guid.Parse("53634a9a-7ebd-48af-979f-b08bf7d0e217"),
                    IdItem = Guid.Parse("2aea14eb-dd41-4ce6-ba90-ad3a82553e25")
                },
                new ItemExtra
                {
                    IdExtra = Guid.Parse("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"),
                    IdItem = Guid.Parse("b9d81522-7e29-47b1-bc63-b80fa6241872")
                }
            );
        }
    }
}
