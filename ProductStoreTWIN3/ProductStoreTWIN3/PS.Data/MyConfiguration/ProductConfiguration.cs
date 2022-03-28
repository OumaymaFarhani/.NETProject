using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PS.Domain;

namespace PS.Data.MyConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Providers).WithMany(pr=>pr.Products).UsingEntity(t=>t.ToTable("Providings"));
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p=>p.CategoryFk).OnDelete(DeleteBehavior.Cascade);




        }
    }
}
