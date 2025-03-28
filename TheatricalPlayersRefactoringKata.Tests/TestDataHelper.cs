using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Tests;

public static class TestDataHelper
{
    public static StatementData CreateSampleStatementData()
    {
        return new StatementData
        {
            Customer = "TestCustomer",
            Performances = new List<PerformanceData>
            {
                new() { PlayName = "Hamlet", Amount = 650, Audience = 55 },
                new() { PlayName = "Othello", Amount = 456, Audience = 40 }
            },
            TotalAmount = 1106,
            TotalCredits = 47
        };
    }
}