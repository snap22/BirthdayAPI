using BirthdayAPI.Core.Service.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Validators
{
    public class ProfileValidator : AbstractValidator<ProfileDto>
    {
        public ProfileValidator()
        {
            RuleFor(p => p.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5);

            RuleFor(p => p.Bio)
                .MaximumLength(200);
        }

    }
}