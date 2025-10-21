using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<CreateClientResponse>>
{
    private readonly ClientFirestoreService _clientFirestoreService;

    public GetAllClientsHandler(ClientFirestoreService clientFirestoreService)
        => _clientFirestoreService = clientFirestoreService;

    public async Task<IEnumerable<CreateClientResponse>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _clientFirestoreService.GetClientsAsync();

        var response = clients.Select(c => new CreateClientResponse
        {
            Id = c.Id,
            Email = c.Email,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Phone = c.Phone
        });

        return response;
    }
}

