using InvestmentCalculatorAPI.Models;
using InvestmentCalculatorAPI.Services.Contracts;

namespace InvestmentCalculatorAPI.Services;

public class InvestmentCalculator : IInvestmentCalculator
{
    public double CalculateInterestSum(InvestmentDetails investmentDetails)
    {
        double interestSum = 0;

        // Calculate the monthly interest rate 
        double monthlyInterestRate = investmentDetails.InterestRate / 12;

        // Calculate the number of months between the calculation date and the end date of the investment
        int months = (investmentDetails.AgreementDate.AddYears(investmentDetails.Duration).Year - investmentDetails.CalculationDate.Year) * 12 + 
                     (investmentDetails.AgreementDate.AddYears(investmentDetails.Duration).Month - investmentDetails.CalculationDate.Month);

        for (int i = 0; i < months; i++)
        {
            // Calculate the interest amount for the current month
            double interestAmount = investmentDetails.Principal * monthlyInterestRate;

            // Add the interest amount to the interest sum
            interestSum += interestAmount;

            // Subtract the monthly payment from the principal
            investmentDetails.Principal -= CalculateMonthlyPayment(investmentDetails) - interestAmount;
        }

        // Return the interest sum
        return interestSum;
    }

    private double CalculateMonthlyPayment(InvestmentDetails investmentDetails)
    {
        // Use the formula for annuity payment
        return investmentDetails.Principal * (investmentDetails.InterestRate / 12 * Math.Pow(1 + investmentDetails.InterestRate / 12, investmentDetails.Duration * 12)) / 
               (Math.Pow(1 + investmentDetails.InterestRate / 12, investmentDetails.Duration * 12) - 1);
    }
}