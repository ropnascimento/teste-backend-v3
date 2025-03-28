namespace TheatricalPlayersRefactoringKata
{

    public interface IPlayCalculator
    {
        decimal CalculateAmount(int lines, int audience);
        int CalculateAdditionalCredits(int audience);
    }
}