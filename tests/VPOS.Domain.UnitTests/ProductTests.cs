using FluentAssertions;
using VPOS.Domain.Entities;
using VPOS.Domain.Enums;
using VPOS.Domain.Exceptions;
using Xunit;

namespace VPOS.Domain.UnitTests
{
    public class ProductTests
    {
        [Fact]
        public void ShouldHaveStatusInStock()
        {
            var product = new Product();

            product.Status.Should().Be(ProductStatus.InStock);
        }

        [Fact]
        public void ChangeProductStatusShouldHaveUpdatedState()
        {
            var product = new Product();

            product.ChangeStatus(ProductStatus.Sold);

            product.Status.Should().Be(ProductStatus.Sold);
        }

        [Fact]
        public void SellProductShouldReturnTrue()
        {
            var product = new Product();

            product.SellProduct();

            product.Status.Should().Be(ProductStatus.Sold);
        }

        [Fact]
        public void SellProductShouldThrowProductAlreadySoldException()
        {
            var product = new Product();

            product.ChangeStatus(ProductStatus.Sold);

            FluentActions.Invoking(() => product.SellProduct()).Should().Throw<ProductAlreadySoldException>();
        }

        [Fact]
        public void SellProductShouldThrowProductIsDamagedException()
        {
            var product = new Product();

            product.ChangeStatus(ProductStatus.Damaged);

            FluentActions.Invoking(() => product.SellProduct()).Should().Throw<ProductIsDamagedException>();
        }
    }
}
