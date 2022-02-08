using CarShowRoom.Models.Requests;
using FluentValidation;

namespace CarShowRoom.Validators
{
    public class CarRequestValidator : AbstractValidator<CarRequest>
    {
        public CarRequestValidator()
        {
            RuleFor(x => x.Brand).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Model).NotNull().NotEmpty().MinimumLength(2).MaximumLength(15);
            RuleFor(x => x.FuelType).IsInEnum();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Year).NotNull().NotEmpty().GreaterThan(1900).LessThan(2023);
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}
