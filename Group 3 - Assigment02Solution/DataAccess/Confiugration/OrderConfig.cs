using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.RequiredDate);
            builder.Property(x => x.OrderDate);
            builder.Property(x => x.Freight);
            builder.Property(x => x.ShippedDate);
            builder.HasOne(o => o.Member)
                .WithMany(x => x.Orders)
                .HasForeignKey(o => o.MemberId);
        }
    }
}
