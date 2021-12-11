using System;
using FactoryPattern.Enums;
using FactoryPattern.Models;
using FactoryPattern.Shipping;

namespace FactoryPattern
{
    public class ShoppingCart
    {
        private readonly Order _order;

        public ShoppingCart(Order order)
        {
            _order = order;
        }

        public string FinalizeOrder()
        {
            #region Create Shipping Provider
            ShippingProvider shippingProvider;

            if (_order.Sender.Country == "Australia")
            {
                #region Australia Post Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 250,
                    extraWeightFee: 500)
                {
                    ShippingType = ShippingType.Standard
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PrePaid
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = false,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamage = false
                };

                shippingProvider = new AustraliaPostShippingProvider(
                    "CLIENT_ID",
                    "SECRET",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else if (_order.Sender.Country == "Sweden")
            {
                #region Swedish Postal Service Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 50,
                    extraWeightFee: 100)
                {
                    ShippingType = ShippingType.Express
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PayOnArrival
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = true,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamage = false
                };

                shippingProvider = new SwedishPostalServiceShippingProvider(
                    "API_KEY",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }
            #endregion

            _order.ShippingStatus = ShippingStatus.ReadyForShipment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}
