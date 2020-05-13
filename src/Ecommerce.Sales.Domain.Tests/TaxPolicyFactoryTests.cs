using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class TaxPolicyFactoryTests
    {
        [TestMethod]
        public void Create_When_CustomerIsForeigner_Then_ForeignerTaxPolicy()
        {
            //Arrange
            var customer = new Customer(false, true, true);
            var taxFactory = new TaxPolicyFactory();

            //Act
            var taxPolicy = taxFactory.CreateTaxPolicy(customer);

            //Assert
            Assert.IsTrue(taxPolicy is ForeignerTaxPolicy);
        }

        [TestMethod]
        public void Create_When_CustomerIsNotForeigner_Then_StandardTaxPolicy()
        {
            //Arrange
            var customer = new Customer(false, false, false);
            var taxFactory = new TaxPolicyFactory();

            //Act
            var taxPolicy = taxFactory.CreateTaxPolicy(customer);

            //Assert
            Assert.IsTrue(taxPolicy is StandardTaxPolicy);
        }
    }
}
