using TheatricalPlayersRefactoringKata.PlayCalculators;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class TragedyCalculatorTests
{
    private readonly TragedyCalculator _calculator = new();

    [Theory]
    [InlineData(30, 300)] // Base
    [InlineData(31, 300 + 10)] // +1 audience
    [InlineData(40, 300 + 100)] // +10 audience
    public void CalculateAmount_VariousAudience_ReturnsCorrectAmount(int audience, int expected)
    {
        // Arrange
        const int lines = 3000;
        
        // Act
        var result = _calculator.CalculateAmount(lines, audience);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateAdditionalCredits_AlwaysZero()
    {
        var result = _calculator.CalculateAdditionalCredits(40);
        Assert.Equal(0, result);
    }
}