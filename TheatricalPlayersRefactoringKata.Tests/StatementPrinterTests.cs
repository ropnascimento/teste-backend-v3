using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.StatementFormatters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    

    private readonly Dictionary<string, Play> plays = new Dictionary<string, Play>
    {
        { "Hamlet", new Play("Hamlet", 4024, "tragedy") },
        { "As-Like", new Play("As You Like It", 2670, "comedy") },
        { "Othello", new Play("Othello", 3560, "tragedy") },
        { "Henry-V", new Play("Henry V", 3227, "history") },
        { "King-John", new Play("King John", 2648, "history") },
        { "Richard-III", new Play("Richard III", 3718, "history") },
    };
     private readonly Invoice invoice = new Invoice(
        "BigCo",
            new List<Performance>
            {
                new Performance("Hamlet", 55),
                new Performance("As-Like", 35),
                new Performance("Othello", 40),
                new Performance("Henry-V", 20),
                new Performance("King-John", 39),
                new Performance("Henry-V", 20)
            }
     );
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, "tragedy"));
        plays.Add("as-like", new Play("As You Like It", 2670, "comedy"));
        plays.Add("othello", new Play("Othello", 3560, "tragedy"));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
            }
        );

        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        // Act
        var statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays, new XmlFormatter());
        // Assert
        Approvals.Verify(result);
    }
}
