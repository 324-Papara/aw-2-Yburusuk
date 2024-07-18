using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validations;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("FirstName must be between 2 and 30 characters!");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("LastName must be between 2 and 30 characters.");

        RuleFor(x => x.IdentityNumber)
            .NotEmpty()
            .Length(11)
            .WithMessage("IdentityNumber must be 11 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email must be a valid email address.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty();

        RuleFor(x => x.CustomerNumber)
            .NotEmpty()
            .InclusiveBetween(1,1000)
            .WithMessage("CustomerNumber must be between 1 and 1000.");
    }
}