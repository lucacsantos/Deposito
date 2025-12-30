using Deposito.Domain.Commands.Request;
using FluentValidation;

namespace Deposito.Domain.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do produto é obrigatório.").NotNull().NotEqual("string"); ;
        }
    }
}
