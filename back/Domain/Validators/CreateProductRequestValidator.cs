using Deposito.Domain.Commands.Request;
using FluentValidation;

namespace Deposito.Domain.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do produto é obrigatório.").NotNull().NotEqual("string");
        }
    }
}
