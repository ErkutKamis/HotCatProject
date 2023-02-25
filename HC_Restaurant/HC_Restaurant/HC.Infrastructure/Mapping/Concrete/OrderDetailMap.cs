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
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.ID);

            //builder.Property(x => x.Price).HasConversion<Decimal>().IsRequired(true);
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired(true);

            builder.Property(x => x.Quantity).IsRequired(true);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.OrderDetails)
               .HasForeignKey(x => x.ProductID);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderID); 

            base.Configure(builder);
        }
    }
}
