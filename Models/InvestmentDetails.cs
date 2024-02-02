namespace InvestmentCalculatorAPI.Models;

public class InvestmentDetails
{
    public DateTime AgreementDate { set; get; }
    public DateTime CalculationDate { set; get; }
    public double Principal { set; get; }
    public double InterestRate { set; get; }
    public int Duration { set; get; }
}