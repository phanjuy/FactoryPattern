using FactoryPattern.Enums;
using FactoryPattern.Models;
using FactoryPattern.Shipping;

namespace FactoryPattern
{
    public class ShoppingCart
    {
        private readonly Order _order;

        public ShoppingCart(Order order)
        {
            _order = order;
        }

        public string FinalizeOrder()
        {
            var shippingProvider = ShippingProviderFactory.CreateShippingProvider(_order.Sender.Country);

            _order.ShippingStatus = ShippingStatus.ReadyForShipment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}
