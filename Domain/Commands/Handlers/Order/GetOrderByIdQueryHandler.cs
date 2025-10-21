using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, CreateOrderResponse>
    {
        
        private readonly OrderFirestoreService _orderFirestoreService;

        public GetOrderByIdQueryHandler(OrderFirestoreService orderFirestoreService)
            => _orderFirestoreService = orderFirestoreService;

        public async Task<CreateOrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderFirestoreService.GetOrderAsyncId(request.Id);

            if (order is null) 
                throw new Exception("Pedido não encontrado");

            return new CreateOrderResponse()
            {
                Id = order.Id,
                Addres = order.Addres,
                InStorePickup = order.InStorePickup,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
            };
        }
    }
}
