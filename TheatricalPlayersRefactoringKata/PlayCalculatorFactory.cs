namespace TheatricalPlayersRefactoringKata;
using TheatricalPlayersRefactoringKata.PlayCalculators;

public static class PlayCalculatorFactory
{
    public static IPlayCalculator CreateCalculator(string playType)
    {
        return playType switch
        {
            "tragedy" => new TragedyCalculator(),
            "comedy" => new ComedyCalculator(),
            "history" => new HistoryCalculator(),
            _ => throw new System.ArgumentException("Unknown play type: " + playType)
        };
    }
}