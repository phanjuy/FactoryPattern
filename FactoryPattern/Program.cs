using System;
using FactoryPattern.Models;
using FactoryPattern.Purchase;

namespace FactoryPattern
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine()!.Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine()!.Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine()!.Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Santa Claus",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion

            var factoryProvider = new PurchaseFactoryProvider();
            var purchaseFactory = factoryProvider.CreateFactoryFor(order.Sender.Country);

            if (purchaseFactory is null)
            {
                throw new NotSupportedException("Sender country has no purchase provider");
            }

            var cart = new ShoppingCart(order, purchaseFactory);

            var shippingLabel = cart.FinalizeOrder();

            Console.WriteLine(shippingLabel);
        }
    }
}
