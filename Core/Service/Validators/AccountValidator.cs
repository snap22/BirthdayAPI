using BirthdayAPI.Core.Service.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Validators
{
    public class AccountValidator : AbstractValidator<AccountDto>
    {
        public AccountValidator()
        {
            RuleFor(account => account.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);
                

            RuleFor(account => account.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5);
        }
    }
}
