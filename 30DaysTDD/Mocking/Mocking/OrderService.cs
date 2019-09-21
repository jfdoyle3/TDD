using System;
using System.Linq;

namespace ThirtyDaysOfTDD.UnitTests
{
    class OrderService
    {
        private ICustomerService _customerService;
        private ILoggingService _loggingService;
        private IOrderDataService _orderDataService;

        public OrderService(IOrderDataService orderDataService, ICustomerService customerService, ILoggingService loggingService)
        {
            _orderDataService = orderDataService;
            _customerService = customerService;
            _loggingService = loggingService;
        }

        public Guid PlaceOrder(Guid customerId, IShoppingCart shoppingCart)
        {
            var order = new Order();

            // Business logic that validates order and creates Order object

            var orderId = Save(order);

            _customerService.AddOrderToCustomer(customerId, orderId);
            _loggingService.LogNewOrder(orderId);

            return orderId;
        }

        private Guid Save(Order order)
        {
            return _orderDataService.Save(order);
        }
    }

    public interface IOrderDataService
    {
        Guid Save(Order order);
    }

    public interface ICustomerService
    {
        bool AddOrderToCustomer(Guid customerId, Guid orderId);
    }

    public interface ILoggingService
    {
        bool LogNewOrder(Guid orderId);
    }

    public interface IShoppingCart
    {

    }

    public class Order
    {

    }
}