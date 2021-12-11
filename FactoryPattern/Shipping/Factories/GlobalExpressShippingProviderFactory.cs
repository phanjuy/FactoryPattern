namespace FactoryPattern.Shipping.Factories
{
    public class GlobalExpressShippingProviderFactory : ShippingProviderFactory
    {
        protected override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}
