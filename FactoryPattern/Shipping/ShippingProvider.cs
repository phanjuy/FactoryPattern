using FactoryPattern.Enums;
using FactoryPattern.Models;

namespace FactoryPattern.Shipping
{
    public abstract class ShippingProvider
    {
        public ShippingCostCalculator ShippingCostCalculator { get; protected set; } = default!;

        public CustomsHandlingOptions CustomsHandlingOptions { get; protected set; } = default!;

        public InsuranceOptions InsuranceOptions { get; protected set; } = default!;

        public bool RequireSignature { get; set; }

        public abstract string GenerateShippingLabelFor(Order order);
    }
}
