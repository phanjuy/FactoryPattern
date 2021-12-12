using FactoryPattern.Invoice;
using FactoryPattern.Models;
using FactoryPattern.Shipping;
using FactoryPattern.Shipping.Factories;
using FactoryPattern.Summary;

namespace FactoryPattern.Purchase
{
    public class SwedenPurchaseFactory : IPurchaseFactory
    {
        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ISummary CreateSummary(Order order)
        {
            // Translate email to Swedish
            return new EmailSummary();
        }
    }
}
