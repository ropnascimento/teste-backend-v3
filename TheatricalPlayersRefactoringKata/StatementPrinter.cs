using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.StatementFormatters;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        return Print(invoice, plays, new TextFormatter());
    }

    public string Print(Invoice invoice, Dictionary<string, Play> plays, IStatementFormatter formatter)
    {
        var calculator = new InvoiceCalculator(plays);
        var statementData = calculator.ProcessInvoice(invoice);
        return formatter.Format(statementData);
    }
}