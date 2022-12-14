using System;

namespace StockManager.AdministrationContext.Domain
{
    public class Product : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsRemoved { get; private set; }

        public Product(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name not be null");

            Name = name;
            Description = description;
            Id = Guid.NewGuid();
            IsRemoved = false;
        }
        
        public void SetAsRemoved()
        {
            IsRemoved = true;
        }
    }
}
