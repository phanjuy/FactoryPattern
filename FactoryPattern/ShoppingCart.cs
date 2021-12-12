using FactoryPattern.Enums;
using FactoryPattern.Models;
using FactoryPattern.Purchase;

namespace FactoryPattern
{
    public class ShoppingCart
    {
        private readonly Order _order;
        private readonly IPurchaseFactory _factory;

        public ShoppingCart(
            Order order,
            IPurchaseFactory factory)
        {
            _order = order;
            _factory = factory;
        }

        public string FinalizeOrder()
        {
            var invoice = _factory.CreateInvoice(_order);
            invoice.GenerateInvoice();

            var summary = _factory.CreateSummary(_order);
            summary.Send();

            _order.ShippingStatus = ShippingStatus.ReadyForShipment;

            var shippingProvider = _factory.CreateShippingProvider(_order);
            var label = shippingProvider.GenerateShippingLabelFor(_order);

            return label;
        }
    }
}
