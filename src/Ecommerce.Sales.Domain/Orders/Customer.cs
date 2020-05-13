using System;

namespace Sales.Domain.Orders
{
    public class Customer
    {
        public readonly int _minOrdersWhenDebtor = 10;
        public readonly double _minAllowedOrderTotalPriceWhenDebtor = 20000;

        public Guid Id { get; private set; }
        public bool IsDebtor { get; private set; }
        public bool IsVip { get; private set; }
        public bool IsForeigner { get; private set; }

        public Customer()
        {

        }

        public Customer(bool isDebtor, bool isVip, bool isForeigner)
        {
            Id = Guid.NewGuid();
            IsDebtor = isDebtor;
            IsVip = isVip;
            IsForeigner = isForeigner;
        }

        public bool MeetsOrderPurchaseCriteria(CustomerOrders customerOrders)
        {
            if (customerOrders.Orders == null)
                return false;

            return customerOrders.Orders.Count >= _minOrdersWhenDebtor &&
                   customerOrders.GetTotalPriceFromAllOrders() >= _minAllowedOrderTotalPriceWhenDebtor;
        }
    }
}
