using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        //{
        //    var products = 
        //}
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
    }
}
