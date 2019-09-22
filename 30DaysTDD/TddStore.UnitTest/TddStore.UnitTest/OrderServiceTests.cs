using System;
using System.Linq;
using NUnit.Framework;
using TddStore.Core;
using TddStore.Core.Exceptions;
using Telerik.JustMock;

namespace TddStore.UnitTests
{
    [TestFixture]
    class OrderServiceTests
    {
        private OrderService _orderService;
        private IOrderDataService _orderDataService;
        private ICustomerService _customerService;
        

        [OneTimeSetUp] // NUnit2 ~ [TestFixtureSetup]
        public void SetupOneTime()
        {
            _orderDataService = Mock.Create<IOrderDataService>();
            _customerService = Mock.Create<ICustomerService>();
            _customerService = Mock.Create<ICustomerService>();
            _orderService = new OrderService(_orderDataService,_customerService);
            

        }


        [Test]
        public void WhenUserPlacesACorrectOrderThenAnOrderNumberShouldBeReturned()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.Items.Add(new ShoppingCartItem { ItemId = Guid.NewGuid(), Quantity = 1 });
            var customerId = Guid.NewGuid();
            var expectedOrderId = Guid.NewGuid();

     
            Mock.Arrange(() => _orderDataService.Save(Arg.IsAny<Order>()))
                .Returns(expectedOrderId)
                .OccursOnce();
           

            //Act
            var result = _orderService.PlaceOrder(customerId, shoppingCart);

            //Assert
            Assert.AreEqual(expectedOrderId, result);
            Mock.Assert(_orderDataService);
        }

        [Test]

        public void WhenAUserAttemptsToOrderAnItemWithAQuantityOfZeroThrowInvalidOrderException()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.Items.Add(new ShoppingCartItem { ItemId = Guid.NewGuid(), Quantity = 0 });
            var customerId = Guid.NewGuid();
            var expectedOrderId = Guid.NewGuid();

            Mock.Arrange(() => _orderDataService.Save(Arg.IsAny<Order>()))
                .Returns(expectedOrderId)
                .OccursNever();

            //Act
            try
            {
                _orderService.PlaceOrder(customerId, shoppingCart);
            }
            catch (InvalidOrderException ex)
            {
                //Assert
                Mock.Assert(_orderDataService);
                Assert.Pass();
            }

            //Assert
            Assert.Fail();
        }

        [Test]
        public void WhenAValidCustomerPlacesAValidOrderAnOrderShouldBePlaced()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.Items.Add(new ShoppingCartItem { ItemId = Guid.NewGuid(), Quantity = 1 });
            var customerId = Guid.NewGuid();
            var customerToReturn = new Customer { Id = customerId, FirstName = "Fred", LastName = "Flintstone" };

            Mock.Arrange(() => _customerService.GetCustomer(customerId))
                            .Returns(customerToReturn)
                            .OccursOnce();


            //Act
            _orderService.PlaceOrder(customerId, shoppingCart);

            //Assert

            Mock.Assert(_customerService);

        }
    }
}