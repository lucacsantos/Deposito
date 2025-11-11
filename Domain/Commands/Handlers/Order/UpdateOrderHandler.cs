using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly OrderFirestoreService _orderFirestoreService;

        public UpdateOrderHandler(OrderFirestoreService orderFirestoreService) 
            => _orderFirestoreService = orderFirestoreService;

        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderFirestoreService.GetOrderAsyncId(request.Id);

            if(order is null)
                throw new Exception("Pedido não encontrado.");

            order.Address = request.Address;
            order.InStorePickup = request.InStorePickup;
            order.PaymentMethod = request.PaymentMethod;
            order.Status = request.Status;

            await _orderFirestoreService.UpdateOrderAsync(order);

            return new UpdateOrderResponse
            {
                Id = Guid.Parse(order.Id),
                Addres = order.Address,
                InStorePickup = order.InStorePickup,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status
            };
        }
    }
}
