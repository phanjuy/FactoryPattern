using System;
using FactoryPattern.Enums;

namespace FactoryPattern.Shipping
{
    public class ShippingCostCalculator
    {
        private readonly decimal _internationalShippingFee;
        private readonly decimal _extraWeightFee;

        public ShippingType ShippingType { get; set; }

        public ShippingCostCalculator(
            decimal internationalShippingFee,
            decimal extraWeightFee,
            ShippingType shippingType = ShippingType.Standard)
        {
            _internationalShippingFee = internationalShippingFee;
            _extraWeightFee = extraWeightFee;

            ShippingType = shippingType;
        }

        public decimal CalculateFor(
            string destinationCountry,
            string originCountry,
            decimal weight)
        {
            decimal total = 10m; // Default shipping cost $10

            // International shipping
            if (destinationCountry != originCountry)
            {
                total += _internationalShippingFee;
            }

            // Over 5kg
            if (weight > 5)
            {
                total += _extraWeightFee;
            }

            switch (ShippingType)
            {
                case ShippingType.Express: total += 20; break;
                case ShippingType.NextDay: total += 50; break;
                case ShippingType.Standard: break;
                default: throw new ArgumentOutOfRangeException();
            }

            return total;
        }
    }
}
