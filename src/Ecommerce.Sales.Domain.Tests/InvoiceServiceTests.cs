using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices;
using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;
using System;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class InvoiceServiceTests
    {
        [TestMethod]
        public void CreateInvoice()
        {
            //Arrange
            Product firstProduct = new Product(new Guid(), 100, ProductType.Audio);
            Product secondProduct = new Product(new Guid(), 100, ProductType.TV);
            Customer customer = new Customer(false, false, false);
            Order order = new Order(customer);
            order.AddProduct(firstProduct, 2);
            order.AddProduct(secondProduct, 1);

            var taxPolicy = new TaxPolicyFactory().CreateTaxPolicy(order.Customer);

            //Act
            var invoice = new InvoiceService().CreateInvoice(order, taxPolicy);

            //Assert
            invoice.Lines.Count.Should().Be(2);
            invoice.NettPrice.Should().Be(300);
            invoice.GrossPrice.Should().Be(330);
        }
    }
}