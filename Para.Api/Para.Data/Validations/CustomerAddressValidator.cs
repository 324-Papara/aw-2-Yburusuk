using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validations;

public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
{
    public CustomerAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .Length(1, 25);

        RuleFor(x => x.City)
            .NotEmpty()
            .Length(1, 190);

        RuleFor(x => x.AddressLine)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .Length(11);
    }
}