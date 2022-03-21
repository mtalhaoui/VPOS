using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VPOS.Application.Products.Commands.ChangeProductStatus;
using VPOS.Application.Products.Commands.CreateProduct;
using VPOS.Application.Products.Commands.SellProduct;
using VPOS.Application.Products.Queries.GetProductCountByStatus;
using VPOS.Domain.Enums;

namespace VPOS.Api.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet("ProductCountForStatus")]
        public async Task<ActionResult<int>> GetProductCountForStatus([FromQuery] ProductStatus status) => await Mediator.Send(new GetProductCountByStatusQuery(status));

        [HttpPut("ChangeStatus/{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] ChangeProductStatusCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("SellProduct/{id:guid}")]
        public async Task<ActionResult> SellProduct(Guid id)
        {
            await Mediator.Send(new SellProductCommand(id));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductCommand command) => new JsonResult(await Mediator.Send(command));
    }
}
