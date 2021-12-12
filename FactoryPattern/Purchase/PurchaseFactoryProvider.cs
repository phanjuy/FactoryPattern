using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FactoryPattern.Purchase
{
    public class PurchaseFactoryProvider
    {
        private readonly IEnumerable<Type> factories;

        public PurchaseFactoryProvider()
        {
            factories = Assembly.GetAssembly(typeof(PurchaseFactoryProvider))!
                .GetTypes()
                .Where(t => typeof(IPurchaseFactory)
                .IsAssignableFrom(t));
        }

        public IPurchaseFactory? CreateFactoryFor(string name)
        {
            var factory = factories
                .Single(x => x.Name.ToLowerInvariant()
                .Contains(name.ToLowerInvariant()));

            var instance = Activator.CreateInstance(factory) as IPurchaseFactory;

            return instance;
        }
    }
}
