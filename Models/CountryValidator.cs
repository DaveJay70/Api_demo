using FluentValidation;


namespace Api_demo.Models
{
    public class CountryValidator:AbstractValidator<CountryModel>
    {
        public CountryValidator()
        {
            RuleFor(u => u.CountryName)
                .NotEmpty()
                .WithMessage("CountryName Compulsory ")
                .MaximumLength(5);
        }
    }
}
