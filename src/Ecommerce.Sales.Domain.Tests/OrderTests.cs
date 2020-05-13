using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Orders;
using FluentAssertions;
using Sales.Application.Exceptions;

namespace Sales.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void AddProduct_WhenAddsAnotherProduct_ThenSecondProductIsAdded()
        {
            //Arrange
            Product firstProduct = new Product(new Guid(), 10, ProductType.Audio);
            Product secondProduct = new Product(new Guid(), 10, ProductType.TV);
            Order order = new Order(new Customer());

            //Act
            order.AddProduct(firstProduct, 1);
            order.AddProduct(secondProduct, 1);

            //Assert
            order.OrderLines.Count.Should().Be(2);
        }

        [TestMethod]
        public void AddProduct_WhenAddsExistingProduct_ThenQuantityIsIncreased()
        {
            //Arrange
            Product product = new Product(new Guid(), 10, ProductType.TV);
            Order order = new Order(new Customer());

            //Act
            order.AddProduct(product, 1);
            order.AddProduct(product, 2);

            //Assert
            order.OrderLines.Count.Should().Be(1);
            order.OrderLines.First().Quantity.Should().Be(3);
        }

        [TestMethod]
        public void Accept_WhenCustomerIsVip_ThenOrderIsAccepted()
        {
            //Arrange
            Customer customer = new Customer(false, true, true);
            Order order = new Order(customer);

            //Act
            Action act = () => order.Accept();

            //Assert
            act.Should().NotThrow<OverduedOrderException>();
            act.Should().NotThrow<CustomerIsDebtorException>();
            order.Status.Should().Be(OrderStatus.Accepted);
            order.AcceptDate.Should().BeCloseTo(DateTime.Now, 1000);
        }

        [TestMethod]
        public void Accept_WhenCustomerIsDebtor_ThenOrderIsNotAccepted()
        {
            //Arrange
            Customer customer = new Customer(true, false, true);
            Order order = new Order(customer);

            //Act
            Action act = () => order.Accept();

            //Assert
            act.Should().Throw<CustomerIsDebtorException>();
        }

        [TestMethod]
        public void Accept_WhenCustomerIsDebtorWithOrders_ThenOrderIsNotAccepted()
        {
            //Arrange
            Customer customer = new Customer(true, false, true);
            Order order = new Order(customer);

            //Act
            Action act = () => order.Accept();

            //Assert
            act.Should().Throw<CustomerIsDebtorException>();

        }

        [TestMethod]
        public void Accept_WhenOrderIsNotOverdued_ThenOrderIsAccepted()
        {
            //Arrange
            Customer customer = new Customer(false, false, true);
            Order order = new Order(customer);

            //Act
            Action act = () => order.Accept();

            //Assert
            act.Should().NotThrow<OverduedOrderException>();
            act.Should().NotThrow<CustomerIsDebtorException>();
            order.Status.Should().Be(OrderStatus.Accepted);
            order.AcceptDate.Should().BeCloseTo(DateTime.Now, 1000);

        }
    }
}
