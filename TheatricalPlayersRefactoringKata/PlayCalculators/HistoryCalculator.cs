using System;
using System.Runtime.InteropServices;

namespace TheatricalPlayersRefactoringKata.PlayCalculators
{

    public class HistoryCalculator : IPlayCalculator
    {
        public decimal CalculateAmount(int lines, int audience)
        {
            decimal tragedy = new TragedyCalculator().CalculateAmount(lines, audience);
            Console.WriteLine(tragedy);
            decimal comedy = new ComedyCalculator().CalculateAmount(lines, audience);
            Console.WriteLine(comedy);
            return tragedy + comedy;
        }

        public int CalculateAdditionalCredits(int audience) => 0;
    }
}