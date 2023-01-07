using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.IRepository;
using Talabat.Core.IService;
using Talabat.Core.ISpecification;

namespace Talabat.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethodId, Address shippingAddress)
        {
            // Get Basket From BasketsRepo
            var basket = await _basketRepository.GetBasketAsync(basketId);

            // Get Selected Item at Basket From ProductsRepo
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);
                var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);
                orderItems.Add(orderItem);
            }

            // Calculate SubTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            // Get DeliveryMethod From DeliveryMethodRepo
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            // Create Order 
            var order = new Order(buyerEmail, shippingAddress, subTotal, deliveryMethod, orderItems);
            await _unitOfWork.Repository<Order>().CreateAsync(order);

            // Save Order to Database
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            var deliveryMethods = await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
            return deliveryMethods;
        }

        public async Task<Order> GetOrderByIdForUserAsync(int orderId, string buyeremail)
        {
            var spec = new OrdersWithItemsAndDeliveryMethodSpecification(orderId, buyeremail);
            var order = await _unitOfWork.Repository<Order>().GetByIdWithSpecification(spec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndDeliveryMethodSpecification(buyerEmail);
            var orders = await _unitOfWork.Repository<Order>().GetAllWithSpecification(spec);
            return orders;
        }
    }
}
