using System;
using System.Collections.Generic;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(string buyerEmail, Address shippingAddress, decimal subTotal, DeliveryMethod deliveryMethod, ICollection<OrderItem> items)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            SubTotal = subTotal;
            DeliveryMethod = deliveryMethod;
            Items = items;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; }

        public string PaymentIntentId { get; set; }

        public decimal SubTotal { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public decimal GetTotal()
            => SubTotal + DeliveryMethod.Cost;
    }
}
