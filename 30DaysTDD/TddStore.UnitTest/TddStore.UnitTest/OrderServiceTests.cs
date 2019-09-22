using System;
using System.Linq;
using NUnit.Framework;
using TddStore.Core;
using Telerik.JustMock;

namespace TddStore.UnitTests
{
    [TestFixture]
    class OrderServiceTests
    {
        private OrderService _orderService;
        private IOrderDataService _orderDataService;

        [OneTimeSetUp] // NUnit2 [TestFixtureSetup]
        public void SetupOneTime()
        {
            _orderDataService = Mock.Create<IOrderDataService>();
            _orderService = new OrderService(_orderDataService);
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
            var orderService = new OrderService(_orderDataService);

            //Act
            var result = _orderService.PlaceOrder(customerId, shoppingCart);

            //Assert
            Assert.AreEqual(expectedOrderId, result);
            Mock.Assert(_orderDataService);
        }

        [Test]
        // [ExpectedException(typeof(InvalidOrderException))]
        public void WhenAUserAttemptsToOrderAnItemWithAQuantityOfZeroThrowInvalidOrderException()
        {
            //Arrange

            //Act
           
           


            //Assert
            Assert.That(() =>_orderService.PlaceOrder(customerId, shoppingCart),  Throws.TypeOf<InvalidOrderException>());
            Mock.Assert(_orderDataService);
        }
    }
}