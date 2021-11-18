using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EasyOrder.Data.Context
{
    public class EasyOrderContext : DbContext
    {
        public EasyOrderContext(DbContextOptions<EasyOrderContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<CategoryExtra> CategoryExtras { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemExtra> ItemExtras { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyOrderContext).Assembly);

            //Desabilita delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //Gera sequencia
            SequencesConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SequencesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasSequence<int>("NumberOrder")
                .HasMin(1);

            modelBuilder
                .HasSequence<int>("ProductCode")
                .HasMin(1);
        }
    }
}
