using FactoryPattern.Enums;
using FactoryPattern.Models;
using FactoryPattern.Shipping.Factories;

namespace FactoryPattern
{
    public class ShoppingCart
    {
        private readonly Order _order;
        private readonly ShippingProviderFactory _factory;

        public ShoppingCart(
            Order order,
            ShippingProviderFactory factory)
        {
            _order = order;
            _factory = factory;
        }

        public string FinalizeOrder()
        {
            var shippingProvider = _factory.GetShippingProvider(_order.Sender.Country);

            _order.ShippingStatus = ShippingStatus.ReadyForShipment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}
