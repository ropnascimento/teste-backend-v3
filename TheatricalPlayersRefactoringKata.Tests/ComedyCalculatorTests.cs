using TheatricalPlayersRefactoringKata.PlayCalculators;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class ComedyCalculatorTests
{
    private readonly ComedyCalculator _calculator = new();

    [Theory]
    [InlineData(20, 300 + 60)]
    [InlineData(21, 300 + 63 + 100 + 5)]
    [InlineData(30, 300 + 90 + 100 + 50)] 
    public void CalculateAmount_VariousAudience_ReturnsCorrectAmount(int audience, int expected)
    {
        // Arrange
        const int lines = 3000;
        
        // Act
        var result = _calculator.CalculateAmount(lines, audience);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 1)]
    [InlineData(9, 1)]
    [InlineData(10, 2)]
    public void CalculateAdditionalCredits_ReturnsFifthOfAudience(int audience, int expected)
    {
        var result = _calculator.CalculateAdditionalCredits(audience);
        Assert.Equal(expected, result);
    }
}