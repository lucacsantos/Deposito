using Deposito.Domain.Commands.Request;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, Unit>
    {
        private readonly OrderFirestoreService _orderFirestoreService;

        public DeleteOrderHandler(OrderFirestoreService orderFirestoreService)
            => _orderFirestoreService = orderFirestoreService;

        public async Task<Unit> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderFirestoreService.GetOrderAsyncId(request.Id);

            if (order is null)
                throw new Exception("Pedido não encontrado");

            await _orderFirestoreService.DeleteOrderAsync(request.Id);

            return Unit.Value;
        }
    }
}
