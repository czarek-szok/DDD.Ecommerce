using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;
using System;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class StandardTaxPolicyTests
    {
        [TestMethod]
        public void CalculateTax_WhenProdutTypeIsPhone_ThenApplyPhoneTax()
        {
            //Arrange
            var standardTaxPolicy = new StandardTaxPolicy();
            var product = new Product(new Guid(), 10, ProductType.Phone);
            var price = 100;
            //Arrange
            var tax = standardTaxPolicy.CalculateTax(product, price);

            //Assert
            tax.Amount.Should().Be(15);
        }

        [TestMethod]
        public void CalculateTax_WhenProdutTypeIsNotPhone_ThenApplyStandardTax()
        {
            //Arrange
            var standardTaxPolicy = new StandardTaxPolicy();
            var product = new Product(new Guid(), 10, ProductType.TV);
            var price = 100;
            //Arrange
            var tax = standardTaxPolicy.CalculateTax(product, price);

            //Assert
            tax.Amount.Should().Be(10);
        }
    }
}
