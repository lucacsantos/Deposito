using Deposito.Domain.Commands.Responses.Product;
using MediatR;

namespace Deposito.Domain.Commands.Request.Product
{
    public class GetProductByIdQuery : IRequest<CreateProductResponse>
    {
        public Guid Id { get; set; }
        
        public GetProductByIdQuery(Guid id) 
        {
            Id = id;
        }
    }
}
