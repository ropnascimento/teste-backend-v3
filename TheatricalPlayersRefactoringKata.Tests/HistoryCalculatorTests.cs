using TheatricalPlayersRefactoringKata.PlayCalculators;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class HistoryCalculatorTests
{
    private readonly HistoryCalculator _calculator = new();

    [Fact]
    public void CalculateAmount_CombinesTragedyAndComedy()
    {
        // Arrange
        const int lines = 3057;
        const int audience = 35;
        decimal expected = new TragedyCalculator().CalculateAmount(lines, audience) 
                     + new ComedyCalculator().CalculateAmount(lines, audience);
        
        // Act
        decimal result = _calculator.CalculateAmount(lines, audience);
        
        // Assert
        Assert.Equal(expected, result);
    }
}