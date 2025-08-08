using Deposito.Domain.Commands.Request.Product;
using Deposito.Domain.Commands.Responses.Products;
using Deposito.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deposito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductRequest request)
        {
            var result = await _mediator.Send(request);
            try
            {
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateProductRequest request)
        {
            if (id != request.Id)
                return BadRequest("O Id não esxiste");
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteProductRequest(id));
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateProductResponse>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateProductResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetProductByIdQuery(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
