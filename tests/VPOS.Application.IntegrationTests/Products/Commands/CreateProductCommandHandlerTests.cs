using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Application.Products.Commands.CreateProduct;
using VPOS.Application.Products.Commands.Service.Interface;
using VPOS.Domain.Entities;
using Xunit;

namespace VPOS.Application.IntegrationTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private CreateProductCommand _createProductCommand;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly IProductService _productService;
        private readonly Product _product;

        public CreateProductCommandHandlerTests()
        {
            _product = new Product();

            var mockService = new Mock<IProductService>();
            mockService.Setup(s => s.CreateProduct(It.IsAny<Product>())).Returns(Task.FromResult(_product)).Verifiable();
            _productService = mockService.Object;

            _createProductCommandHandler = new CreateProductCommandHandler(_productService);
        }

        [Fact]
        public async Task HandleCreateProductReturnsTrue()
        {
            _createProductCommand = new CreateProductCommand("Product 1", "1234567890123", "Description 1", "1kg");
            var result = await _createProductCommandHandler.Handle(_createProductCommand, CancellationToken.None);

            result.Success.Should().BeTrue();
            result.Message.Should().Be($"Product '{_createProductCommand.Name}' has been added.");
        }

        [Fact]
        public void HandleCreateProductReturnsArgumentNullException()
        {
            _createProductCommand = null;

            FluentActions.Invoking(async () => await _createProductCommandHandler.Handle(_createProductCommand, CancellationToken.None))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
