namespace FactoryPattern.Models
{
    public class Item
    {
        public Item(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}
