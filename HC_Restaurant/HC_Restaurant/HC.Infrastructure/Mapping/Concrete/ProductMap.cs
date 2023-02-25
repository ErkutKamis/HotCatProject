using HC.Domain.Concrete;
using HC.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Infrastructure.Mapping.Concrete
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(3000);
            builder.Property(x => x.UnitPrice).IsRequired(true).HasPrecision(18, 2).HasConversion<decimal>();
            builder.Property(x => x.UnitInStock).IsRequired(true).HasConversion<short>();

            builder.Property(x => x.ImagePath).IsRequired(false).HasMaxLength(1000);

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            base.Configure(builder);
        }
    }
}
