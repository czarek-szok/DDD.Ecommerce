using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Domain.Orders.Policies.Discount;


namespace Sales.Domain.Tests
{
    [TestClass]
    public class CustomerVipDiscountPolicyTests
    {
        [TestMethod]
        public void CalculateDiscount_ShouldCalculateDiscount()
        {
            //Arrange
            var discount = 10;
            var vipDiscountPolicy = new CustomerVipDiscountPolicy(discount);

            //Arrange
            var priceWithDiscount = vipDiscountPolicy.Calculate(100, 1);

            //Assert
            priceWithDiscount.Should().Be(90);
        }
    }
}
