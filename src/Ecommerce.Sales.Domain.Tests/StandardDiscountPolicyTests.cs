using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Orders;
using Sales.Domain.Orders.Policies.Discount;
using System.Collections.Generic;

namespace Sales.Domain.Tests
{
    [TestClass]
    public class StandardDiscountPolicyTests
    {
        [TestMethod]
        public void CalculateDiscount_WhenDiscountCriteriaMet_ThenDiscountIsCalculated()
        {
            //Arrange
            var mininumQuantity = 10;
            var discount = 10;
            var customerOrders = GetCustomerOrders(15, 100);

            var standardDiscountPolicy = new StandardDiscountPolicy(customerOrders, mininumQuantity, discount);

            //Arrange
            var priceWithDiscount = standardDiscountPolicy.Calculate(100, 1);

            //Assert
            priceWithDiscount.Should().Be(90);
        }

        [TestMethod]
        public void CalculateDiscount_WhenDiscountCriteriaDontMet_ThenDiscountIsNotCalculated()
        {
            //Arrange
            var mininumQuantity = 200000;
            var discount = 10;
            var customerOrders = GetCustomerOrders(10, 100);

            var standardDiscountPolicy = new StandardDiscountPolicy(customerOrders, mininumQuantity, discount);

            //Arrange
            var priceWithDiscount = standardDiscountPolicy.Calculate(100, 1);

            //Assert
            priceWithDiscount.Should().Be(100);
        }

        private CustomerOrders GetCustomerOrders(int ordersCount, double orderPrice)
        {
            List<CustomerOrder> orders = new List<CustomerOrder>();

            for (int i = 0; i < ordersCount; i++)
            {
                orders.Add(new CustomerOrder(orderPrice, orderPrice));
            }

            return new CustomerOrders(orders);
        }
    }
}
