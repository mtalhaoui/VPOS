using VPOS.Application.Products.Commands.CreateProduct;

namespace VPOS.Application.IntegrationTests.Products.Commands
{
    public static class ObjectMother
    {
        public static CreateProductCommand NewCreateProductCommand() => new CreateProductCommand("Product 1", "1234567890123", "Description 1", "1kg");
    }
}
