using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {

        private readonly OrderFirestoreService _orderFirestoreService;

        public CreateOrderHandler(OrderFirestoreService orderFirestoreService)
            => _orderFirestoreService = orderFirestoreService;

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Addres = request.Addres,
                InStorePickup = request.InStorePickup,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status
            };

            await _orderFirestoreService.AddOrderAsync(order);

            return new CreateOrderResponse
            {
                Id = order.Id,
                Addres = order.Addres, 
                Status = order.Status,
                InStorePickup = order.InStorePickup,
                PaymentMethod = order.PaymentMethod,
            };
        }

    }
}
