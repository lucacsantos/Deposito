using Deposito.Domain.Commands.Request;
using FluentValidation;
using System.CodeDom;

namespace Deposito.Domain.Validators
{
    public class UpdateOrderRequestValidation: AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidation() 
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("O endereço é obrigatório.");
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("O método de pagamento é obrigatório.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Informe se a retirada é na loja ou na entrega.");
        }
    }
}
