using FluentAssertions;
using VPOS.Domain.Entities;
using VPOS.Domain.Enums;
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
    }
}
