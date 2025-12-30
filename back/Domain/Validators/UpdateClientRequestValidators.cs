using Deposito.Domain.Commands.Request;
using FluentValidation;

namespace Deposito.Domain.Validators
{
    public class UpdateClientRequestValidators : AbstractValidator<UpdateClientRequest>
    {
        public UpdateClientRequestValidators() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Nome é obrigatório.").NotNull().WithName("string");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Sobrenome é obrigatório.").NotNull().NotEqual("string");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(X => X.Phone).NotEmpty().WithMessage("Número de telefone é obrigatório.").NotNull().NotEqual("string");
        }
    }
}
