using FluentValidation;
using InvestmentCalculatorAPI.EndPoints;
using InvestmentCalculatorAPI.Models;
using InvestmentCalculatorAPI.Services;
using InvestmentCalculatorAPI.Services.Contracts;
using InvestmentCalculatorAPI.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<InvestmentDetails>, InvestmentValidator>();
builder.Services.AddScoped<IInvestmentCalculator, InvestmentCalculator>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investment Calculator API V1");
    c.RoutePrefix = string.Empty;
});


app.MapInvestmentEndPoints();

app.Run();