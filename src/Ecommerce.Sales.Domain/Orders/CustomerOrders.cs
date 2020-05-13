using System.Collections.Generic;
using System.Linq;

namespace Sales.Domain.Orders
{
    public class CustomerOrders
    {
        public int CustomerId { get; private set; }
        public IList<CustomerOrder> Orders { get; private set; }

        public CustomerOrders(IList<CustomerOrder> orders)
        {
            Orders = orders;
        }

        public double GetTotalPriceFromAllOrders()
        {
            return Orders.Sum(x => x.TotalPrice);
        }

        public double GetTotalPriceWithDiscountFromAllOrders()
        {
            return Orders.Sum(x => x.TotalPriceWithDiscount);
        }
    }
}
