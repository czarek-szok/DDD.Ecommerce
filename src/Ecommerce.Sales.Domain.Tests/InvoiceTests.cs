using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices;
using Sales.Domain.Orders;
using System;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestMethod]
        public void AddLine_WhenNewLineAdded_ThenGrossAndNettAmountIsRecalculated()
        {
            //Arrange
            var customer = new Customer(false, false, false);
            var product = new Product(new Guid(), 10, ProductType.Phone);
            var line1 = new InvoiceLine(product, 2, 100, new Tax(10, ""));
            var line2 = new InvoiceLine(product, 1, 100, new Tax(10, ""));
            var invoice = new Invoice(customer);

            //Act
            invoice.AddLine(line1);
            invoice.AddLine(line2);

            //Assert
            invoice.Lines.Count.Should().Be(2);
            invoice.NettPrice.Should().Be(200);
            invoice.GrossPrice.Should().Be(220);
        }
    }
}
