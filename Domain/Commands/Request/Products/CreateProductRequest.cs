using Deposito.Domain.Commands.Responses.Products;
using MediatR;

namespace Deposito.Domain.Commands.Request.Product
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageURL { get; set; } = string.Empty;
    }
}
