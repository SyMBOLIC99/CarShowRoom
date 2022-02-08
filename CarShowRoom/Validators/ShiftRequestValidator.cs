using CarShowRoom.Models.Requests;
using FluentValidation;

namespace CarShowRoom.Validators
{
    public class ShiftRequestValidator : AbstractValidator<ShiftRequest>
    {
        public ShiftRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.DaysOfWeek).IsInEnum();
            

        }
    }
}
