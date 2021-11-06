using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.BusinessLogicTests.Fixtures;
using Xunit;
using xUnit_Essentials.Models;

namespace UnitTests.BusinessLogicTests
{
    public class CartBusinessLogicTest : IClassFixture<CartBusinessLogicFixture>
    {
        private readonly CartBusinessLogicFixture _fixture;

        public CartBusinessLogicTest(CartBusinessLogicFixture fixture)
        {
            _fixture = fixture;
        }

        // Tests

        [Fact(DisplayName = "Should return discount price when given current cart total price, discount percentage and maximum discount price allowed")]
        public void ShouldReturnDiscountPriceFact()
        {
            // Assemble
            var businessLogic = _fixture.ContructCartBusinessLogicInstance();

            // Act
            var result = businessLogic.CalculateCouponDiscount(6000, 2, 299.99M);

            // Assert
            Assert.Equal(120, result);
        }

        [Theory(DisplayName = "Should return discount price when given current cart total price, discount percentage and maximum discount price allowed")]
        [InlineData(120, 6000, 2, 299.99)]
        [InlineData(80, 4000, 2, 299.99)]
        public void ShouldReturnDiscountPriceTheory(decimal expectedResult, decimal cartTotal, decimal discountPrec, decimal maxDiscount)
        {
            // Assemble
            var businessLogic = _fixture.ContructCartBusinessLogicInstance();

            // Act
            var result = businessLogic.CalculateCouponDiscount(cartTotal, discountPrec, maxDiscount);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Should return membership discount price when given current cart total price, customer instance")]
        [MemberData(nameof(MembershipDiscountPriceTestData))]
        public void ShouldReturnMembershipDiscountPrice(decimal expectedResult, decimal cartTotal, Customer customer)
        {
            // Assemble
            var businessLogic = _fixture.ContructCartBusinessLogicInstance();

            // Act
            var result = businessLogic.CalculateMembershipDiscount(cartTotal, customer);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> MembershipDiscountPriceTestData =>
        new List<object[]>
        {
            new object[] { 0, 6000, new Customer(DateTime.Now.AddYears(-2)) },
            new object[] { 30, 6000, new Customer(DateTime.Now.AddYears(-4)) },
            new object[] { 60, 6000, new Customer(DateTime.Now.AddYears(-6)) },
            new object[] { 90, 6000, new Customer(DateTime.Now.AddYears(-11))},
        };
    }
}
