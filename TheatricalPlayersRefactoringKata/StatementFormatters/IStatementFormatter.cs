using TheatricalPlayersRefactoringKata.Models;
namespace TheatricalPlayersRefactoringKata.StatementFormatters
{
    public interface IStatementFormatter
    {
        string Format(StatementData data);
    }
}