using System.Linq;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.StatementFormatters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class XmlFormatterTests
{
    [Fact]
    public void Format_ProducesValidXml()
    {
        // Arrange
        var formatter = new XmlFormatter();
        var data = TestDataHelper.CreateSampleStatementData();
        
        // Act
        var result = formatter.Format(data);
        var xmlDoc = XDocument.Parse(result);
        
        // Assert
        Assert.NotNull(xmlDoc);
        Assert.Equal("TestCustomer", xmlDoc.Root?.Attribute("customer")?.Value);
        Assert.Equal(2, xmlDoc.Descendants("performance").Count());
    }
}