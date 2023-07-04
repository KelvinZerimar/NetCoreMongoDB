using Application.App.Commands;
using FluentValidation;

namespace Service.WebApi.Validators
{
    public class SalesValidator : AbstractValidator<SalesCommand>
    {
        public SalesValidator()
        {
            RuleFor(x => x.Country).NotEmpty().Length(0, 100);
            RuleFor(x => x.Region).NotEmpty().EmailAddress();
            RuleFor(x => x.TotalCost).NotEmpty();
        }
    }
}
