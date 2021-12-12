using FactoryPattern.Models;

namespace FactoryPattern.Tests.Fakes
{
    public class StandardOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = "Sweden"
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = "Sweden"
                },

                TotalWeight = 100
            };

            return order;
        }
    }
}