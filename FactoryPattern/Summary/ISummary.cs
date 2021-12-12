using FactoryPattern.Models;

namespace FactoryPattern.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);

        void Send();
    }
}
