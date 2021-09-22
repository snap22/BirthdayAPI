using BirthdayAPI.Core.Service.DTOs;
using FluentValidation;


namespace BirthdayAPI.Core.Service.Validators
{
    public class GiftValidator : AbstractValidator<GiftDto>
    {
        public GiftValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(g => g.Description)
                .MaximumLength(200);

            RuleFor(g => g.EstimatedPrice)
                .GreaterThanOrEqualTo(0);
        }
    }
}
