using FactoryPattern.Invoice;
using FactoryPattern.Models;
using FactoryPattern.Shipping;
using FactoryPattern.Shipping.Factories;
using FactoryPattern.Summary;

namespace FactoryPattern.Purchase
{
    public class AustraliaPurchaseFactory : IPurchaseFactory
    {
        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}
