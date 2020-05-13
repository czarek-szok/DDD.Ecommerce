using System;

namespace Sales.Domain.Orders
{
    public class Product
    {
        public Guid Id { get; private set; }
        public double Price { get; private set; }
        public ProductType Type { get; private set; }

        public Product(Guid id, double price, ProductType type)
        {
            Id = id;
            Price = price;
            Type = type;
        }
    }
}