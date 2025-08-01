﻿using Deposito.Domain.Commands.Handler;
using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest,Unit>
    {
        private static readonly List<Product> products = CreateProductHandler.products;

        public Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(p => p.Id == request.Id);

            if (product is null)
                throw new Exception("Produto não encontrado");

            products.Remove(product);

            return Task.FromResult(Unit.Value);

        }
    }
}
