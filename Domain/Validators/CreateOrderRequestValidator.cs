using Deposito.Domain.Commands.Request;
using FluentValidation;

namespace Deposito.Domain.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("O endereço é obrigatório.");
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("O método de pagamento é obrigatório.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Informe se a retirada é na loja ou na entrega.");
        }

    }
}
