using MediatR;
using VPOS.Application.Common.Response;

namespace VPOS.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CommandResponse>
    {
        public CreateProductCommand(string name, string barcode, string description, string weight)
        {
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
        }

        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public string Description { get; private set; }
        public string Weight { get; private set; }
    }
}
