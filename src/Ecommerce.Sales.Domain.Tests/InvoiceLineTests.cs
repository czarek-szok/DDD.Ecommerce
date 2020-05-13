using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices;
using Sales.Domain.Orders;
using System;

namespace Sales.Domain.Tests
{
    [TestClass]
    public class InvoiceLineTests
    {
        [TestMethod]
        public void CreateInvoiceLine_WhenProductAndTaxProvided_ThenGrossAmountIsCounted()
        {
            //Arrange
            var product = new Product(new Guid(), 10, ProductType.Phone);

            //Act
            var invoiceLine = new InvoiceLine(product, 1, 10, new Tax(0.1, ""));

            //Assert
            invoiceLine.GrossPrice.Should().Be(10.1);
        }
    }
}
