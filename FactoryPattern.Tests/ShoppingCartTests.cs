using System;
using FactoryPattern.Purchase;
using FactoryPattern.Tests.Fakes;
using FluentAssertions;
using Xunit;

namespace FactoryPattern.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void FinalizeOrder_WithoutPurchaseProvider_ThrowsException()
        {
            // Arrange
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var cart = new ShoppingCart(order, null!);

            // Act
            Action act = () => cart.FinalizeOrder();

            // Assert
            act.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void FinalizeOrder_WithSwedenPurchaseProvider_GeneratesShippingLabel()
        {
            // Arrange
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var cart = new ShoppingCart(order, new SwedenPurchaseFactory());

            // Act
            var actual = cart.FinalizeOrder();

            // Assert
            actual.Should().NotBeNull();
        }


        [Fact]
        public void FinalizeOrder_AlreadyFinalized_ThrowsInvalidOperationException()
        {
            // Arrange
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var cart = new ShoppingCart(order, new SwedenPurchaseFactory());

            // Act
            var label = cart.FinalizeOrder();
            Action act = () => cart.FinalizeOrder();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
