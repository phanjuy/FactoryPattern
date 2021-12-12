using FactoryPattern.Models;

namespace FactoryPattern.Summary
{
    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return $"This is an email summary";
        }

        public void Send() { }
    }
}
