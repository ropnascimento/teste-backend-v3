using TheatricalPlayersRefactoringKata.StatementFormatters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class TextFormatterTests
{
    [Fact]
    public void Format_ProducesCorrectStructure()
    {
        // Arrange
        var formatter = new TextFormatter();
        var data = TestDataHelper.CreateSampleStatementData();
        
        // Act
        var result = formatter.Format(data);
        
        // Assert
        Assert.Contains("Statement for TestCustomer", result);
        Assert.Contains("Hamlet: $650.00 (55 seats)", result);
        Assert.Contains("Amount owed is $1,106.00", result);
        Assert.Contains("You earned 47 credits", result);
    }
}