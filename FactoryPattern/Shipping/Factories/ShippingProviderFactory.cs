namespace FactoryPattern.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        protected abstract ShippingProvider CreateShippingProvider(string country);

        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);

            if (country == "Sweden" &&
                provider.InsuranceOptions.ProviderHasInsurance)
            {
                provider.RequireSignature = false;
            }

            return provider;
        }
    }
}
