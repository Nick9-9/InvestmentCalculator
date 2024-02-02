using FluentValidation;
using InvestmentCalculatorAPI.Models;

namespace InvestmentCalculatorAPI.Validation;

public class InvestmentValidator : AbstractValidator<InvestmentDetails>
{
    public InvestmentValidator()
    {
        RuleFor(x => x.AgreementDate)
            .NotEmpty()
            .WithMessage("Agreement date should not be empty.");
        
        RuleFor(x => x.CalculationDate)
            .NotEmpty()
            .WithMessage("Calculation date should not be empty.");
        
        RuleFor(x => x.InterestRate)
            .NotEmpty()
            .WithMessage("Interest rate should not be empty.");
        
        RuleFor(x => x.Principal)
            .NotEmpty()
            .WithMessage("Principal should not be empty.");
        
        RuleFor(x => x.Duration)
            .NotEmpty()
            .WithMessage("Duration should not be empty.");
    }
}