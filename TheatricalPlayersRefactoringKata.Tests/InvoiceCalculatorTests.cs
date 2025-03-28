using System.Collections.Generic;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class InvoiceCalculatorTests
{
    [Fact]
    public void ProcessInvoice_CalculatesTotalsCorrectly()
    {
        // Arrange
        var plays = new Dictionary<string, Play>
        {
            ["hamlet"] = new("Hamlet", 3000, "tragedy"),
            ["as-like"] = new("As You Like It", 3000, "comedy")
        };
        
        var invoice = new Invoice("Test", new List<Performance>
        {
            new("hamlet", 35),
            new("as-like", 25)
        });

        var calculator = new InvoiceCalculator(plays);
        
        // Act
        var result = calculator.ProcessInvoice(invoice);
        
        // Assert
        Assert.Equal(3000/10 + 10*5 + 3000/10 + 3*25 + 100 + 5*5, result.TotalAmount);
        Assert.Equal((35-30) + (25-30 > 0 ? 25-30 : 0) + (int)System.Math.Floor(25m/5), result.TotalCredits);
    }
}