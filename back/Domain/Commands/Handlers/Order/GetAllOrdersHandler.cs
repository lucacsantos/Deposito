using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdesQuery, IEnumerable<CreateOrderResponse>> 
    {
        private readonly OrderFirestoreService _orderFirestoreService;

        public GetAllOrdersHandler(OrderFirestoreService orderFirestoreService)
            => _orderFirestoreService = orderFirestoreService;

        public async Task<IEnumerable<CreateOrderResponse>> Handle(GetAllOrdesQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderFirestoreService.GetOrdersAsync();

            var response = order.Select(o => new CreateOrderResponse
            {
                Id = o.Id,
                Addres = o.Address,
                InStorePickup = o.InStorePickup,
                PaymentMethod = o.PaymentMethod, 
                Status = o.Status
            });

            return response;
        }

    }
}
