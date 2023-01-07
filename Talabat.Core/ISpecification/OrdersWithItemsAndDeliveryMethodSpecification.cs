using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.ISpecification
{
    public class OrdersWithItemsAndDeliveryMethodSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndDeliveryMethodSpecification(string buyerEmail)
            : base(o => o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.Items);
            AddInclude(o => o.DeliveryMethod);

            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndDeliveryMethodSpecification(int orderId, string buyerEmail)
            : base(o => o.Id == orderId && o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.Items);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}
