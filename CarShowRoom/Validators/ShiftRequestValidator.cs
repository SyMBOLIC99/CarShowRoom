using CarShowRoom.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Validators
{
    public class ShiftRequestValidator : AbstractValidator<ShiftRequest>
    {
        public ShiftRequestValidator()
        {
            RuleFor(x => x.DaysOfWeek).IsInEnum();
            

        }
    }
}
