﻿using System;
using FactoryPattern.Enums;
using FactoryPattern.Models;

namespace FactoryPattern.Shipping
{
    public class SwedishPostalServiceShippingProvider : ShippingProvider
    {
        private readonly string _apiKey;

        public SwedishPostalServiceShippingProvider(
            string apiKey,
            ShippingCostCalculator shippingCostCalculator,
            CustomsHandlingOptions customsHandlingOptions,
            InsuranceOptions insuranceOptions)
        {
            _apiKey = apiKey;

            ShippingCostCalculator = shippingCostCalculator;
            CustomsHandlingOptions = customsHandlingOptions;
            InsuranceOptions = insuranceOptions;
        }

        public override string GenerateShippingLabelFor(Order order)
        {
            var shippingId = GetShippingId();

            var shippingCost = ShippingCostCalculator.CalculateFor(
                order.Recipient.Country,
                order.Sender.Country,
                order.TotalWeight);

            return $"Shipping Id: {shippingId} {Environment.NewLine}" +
                   $"To: {order.Recipient.To} {Environment.NewLine}" +
                   $"Order total: {order.Total} {Environment.NewLine}" +
                   $"Tax: {CustomsHandlingOptions.TaxOptions} {Environment.NewLine}" +
                   $"Shipping Cost: {shippingCost}";
        }

        private string GetShippingId()
        {
            // Invoke API with API Key
            return Guid.NewGuid().ToString();
        }
    }
}
