using CarShowRoom.Models.Requests;
using FluentValidation;

namespace CarShowRoom.Validators
{
    public class ClientRequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Balance).NotEmpty();
            

        }
    }
}
