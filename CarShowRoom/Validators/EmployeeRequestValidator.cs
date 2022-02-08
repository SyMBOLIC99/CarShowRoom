using CarShowRoom.Models.Requests;
using FluentValidation;

namespace CarShowRoom.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Salary).NotEmpty().NotNull();

        }
    }
}
