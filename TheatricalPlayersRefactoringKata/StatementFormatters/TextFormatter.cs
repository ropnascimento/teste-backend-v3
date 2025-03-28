using System.Globalization;
using System.Text;

using TheatricalPlayersRefactoringKata.Models;
namespace TheatricalPlayersRefactoringKata.StatementFormatters
{
    public class TextFormatter : IStatementFormatter
    {
        public string Format(StatementData data)
        {
            var result = new StringBuilder();
            CultureInfo cultureInfo = new CultureInfo("en-US");
            result.AppendFormat("Statement for {0}\n", data.Customer);
            foreach (var perf in data.Performances)
            {
                decimal amount = (decimal)perf.Amount;
                result.AppendFormat(cultureInfo, "  {0}: {1:C} ({2} seats)\n", perf.PlayName, amount, perf.Audience);
            }
            decimal totalAmount = (decimal)data.TotalAmount;
            result.AppendFormat(cultureInfo, "Amount owed is {0:C}\n", totalAmount);
            result.AppendFormat("You earned {0} credits\n", data.TotalCredits);
            return result.ToString();
        }
    }
}