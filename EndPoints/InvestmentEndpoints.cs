using FluentValidation;
using InvestmentCalculatorAPI.Models;
using InvestmentCalculatorAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentCalculatorAPI.EndPoints;

public static class InvestmentEndpoints
{
    public static void MapInvestmentEndPoints(this IEndpointRouteBuilder routes)
    {
            var investment = routes.MapGroup("/api/investment");
            
            investment.MapPost(String.Empty, GetInvestmentsDetails);
    }

    public static async Task<IResult> GetInvestmentsDetails(
        [FromBody] InvestmentDetails investment,
        [FromServices] IValidator<InvestmentDetails> validator,
        [FromServices] IInvestmentCalculator investmentCalculator)
    {
        var result = await validator.ValidateAsync(investment);
        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors.Select(x => x.ErrorMessage));
        }

        var futureInterestPayments = investmentCalculator.CalculateInterestSum(investment);
        return Results.Ok(new { FutureInterestPayments = futureInterestPayments });
    }
}