using Deposito.Domain.Commands.Responses.Products;
using MediatR;

namespace Deposito.Domain.Commands.Request.Product
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = string.Empty;
    }
}
