using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;
using TheatricalPlayersRefactoringKata.Models;

public class InvoiceCalculator
{
    private readonly Dictionary<string, Play> _plays;

    public InvoiceCalculator(Dictionary<string, Play> plays)
    {
        _plays = plays;
    }

    public StatementData ProcessInvoice(Invoice invoice)
    {
        var statementData = new StatementData
        {
            Customer = invoice.Customer,
            Performances = new List<PerformanceData>(),
            TotalAmount = 0,
            TotalCredits = 0
        };

        foreach (var perf in invoice.Performances)
        {
            var play = _plays[perf.PlayId];
            var calculator = PlayCalculatorFactory.CreateCalculator(play.Type);
            int clampedLines = Math.Clamp(play.Lines, 1000, 4000);
            decimal amount = calculator.CalculateAmount(clampedLines, perf.Audience);
            int baseCredits = Math.Max(perf.Audience - 30, 0);
            int additionalCredits = calculator.CalculateAdditionalCredits(perf.Audience);

            statementData.Performances.Add(new PerformanceData
            {
                PlayName = play.Name,
                Amount = amount,
                Audience = perf.Audience,
                EarnedCredits = baseCredits + additionalCredits 
            });

            statementData.TotalAmount += amount;
            statementData.TotalCredits += baseCredits + additionalCredits;
        }

        return statementData;
    }
}