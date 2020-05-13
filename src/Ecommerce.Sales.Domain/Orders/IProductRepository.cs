using System;

namespace Sales.Domain.Orders
{
    public interface IProductRepository
    {
        Product Get(Guid productId);
    }
}
