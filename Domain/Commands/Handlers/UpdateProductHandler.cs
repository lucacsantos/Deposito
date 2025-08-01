﻿using Deposito.Domain.Commands.Handler;
using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private static readonly List<Product> products = CreateProductHandler.products;

        public Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(p => p.Id == request.Id);
            if (product is null)
                throw new Exception("Produto não encontrado.");
            product.Id = request.Id;
            product.Name = request.Name;
            product.Price = request.Price;
            product.ImageURL = request.ImageURL;

            return Task.FromResult(new UpdateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            });
        }
    }
}
