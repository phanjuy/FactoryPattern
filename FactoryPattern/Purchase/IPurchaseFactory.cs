using FactoryPattern.Invoice;
using FactoryPattern.Models;
using FactoryPattern.Shipping;
using FactoryPattern.Summary;

namespace FactoryPattern.Purchase
{
    public interface IPurchaseFactory
    {
        ShippingProvider CreateShippingProvider(Order order);

        IInvoice CreateInvoice(Order order);

        ISummary CreateSummary(Order order);
    }
}
