using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;
using System;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class ForeignerTaxPolicyTests
    {
        [TestMethod]
        public void CalculateTax_WhenProdutTypeIsPhone_ThenApplyTaxForForeigner()
        {
            //Arrange
            var foreignerTaxPolicy = new ForeignerTaxPolicy();
            var product = new Product(new Guid(), 10, ProductType.Phone);
            var price = 100;
            //Arrange
            var tax = foreignerTaxPolicy.CalculateTax(product, price);

            //Assert
            tax.Amount.Should().Be(10);
        }

        [TestMethod]
        public void CalculateTax_WhenProdutTypeIsNotPhone_ThenApplyTaxForForeigner()
        {
            //Arrange
            var foreignerTaxPolicy = new ForeignerTaxPolicy();
            var product = new Product(new Guid(), 10, ProductType.Audio);
            var price = 100;
            //Arrange
            var tax = foreignerTaxPolicy.CalculateTax(product, price);

            //Assert
            tax.Amount.Should().Be(10);
        }
    }
}
