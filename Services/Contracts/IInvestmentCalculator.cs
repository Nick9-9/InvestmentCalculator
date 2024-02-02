using InvestmentCalculatorAPI.Models;

namespace InvestmentCalculatorAPI.Services.Contracts;

public interface IInvestmentCalculator
{
    double CalculateInterestSum(InvestmentDetails investmentDetails);
}