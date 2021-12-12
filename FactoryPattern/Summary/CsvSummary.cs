using FactoryPattern.Models;

namespace FactoryPattern.Summary
{
    public class CsvSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is a CSV summary";
        }

        public void Send() { }
    }
}
