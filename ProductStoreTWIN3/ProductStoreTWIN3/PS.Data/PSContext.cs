using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PS.Data.MyConfiguration;
using PS.Domain;
namespace PS.Data
{
    public class PSContext : DbContext
    {
            //les images de contenue des tables-    
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ProductStoreDB;
                                          Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //classe de configuration 1methode
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //2eme methode
           // modelBuilder.Entity<Category>().ToTable("MyCategories");
            //modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            //modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
