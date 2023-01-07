using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, np => np.WithOwner());

            builder.Property(o => o.Status)
                .HasConversion(
                                oStatus => oStatus.ToString(),
                                oStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), oStatus)
                              );

            builder.HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
