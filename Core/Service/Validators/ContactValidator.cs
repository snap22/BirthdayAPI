using BirthdayAPI.Core.Service.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Validators
{
    public class ContactValidator : AbstractValidator<ContactDto>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Date)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2);

            RuleFor(c => c.Info)
                .MaximumLength(200);
        }
    }
}
