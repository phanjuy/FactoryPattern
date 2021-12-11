using System.Collections.Generic;
using System.Linq;
using FactoryPattern.Enums;

namespace FactoryPattern.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue
            => LineItems.Sum(item => item.Key.Price * item.Value)
               - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal Total
            => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        public Address Recipient { get; set; } = default!;

        public Address Sender { get; set; } = default!;

        public decimal TotalWeight { get; set; }
    }
}
