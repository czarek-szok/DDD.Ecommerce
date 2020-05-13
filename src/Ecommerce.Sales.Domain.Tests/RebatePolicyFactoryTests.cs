using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Orders;
using Sales.Domain.Orders.Policies.Discount;
using System.Collections.Generic;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class DiscountPolicyFactoryTests
    {
        [TestMethod]
        public void Create_When_CustomerIsVip_Then_CustomerVipDiscountPolicy()
        {
            //Arrange
            var customerOrders = GetCustomerOrders(10, 10);
            var customer = new Customer(false, true, false);
            var discountFactory = new DiscountPolicyFactory(customerOrders);

            //Act
            var discountPolicy = discountFactory.Create(customer);

            //Assert
            Assert.IsTrue(discountPolicy is CustomerVipDiscountPolicy);
        }

        [TestMethod]
        public void Create_When_CustomerIsNotVip_Then_StandardDiscountPolicy()
        {
            //Arrange
            var customerOrders = GetCustomerOrders(10, 10);
            var customer = new Customer(false, false, false);
            var discountFactory = new DiscountPolicyFactory(customerOrders);

            //Act
            var discountPolicy = discountFactory.Create(customer);

            //Assert
            Assert.IsTrue(discountPolicy is StandardDiscountPolicy);
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
