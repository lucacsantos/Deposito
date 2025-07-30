using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
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
