using System;

namespace TheatricalPlayersRefactoringKata.PlayCalculators
{

    public class TragedyCalculator : IPlayCalculator
    {
        public decimal CalculateAmount(int lines, int audience)
        {
            decimal baseAmount = (decimal)lines / 10;
            if (audience > 30)
                baseAmount += 10 * (audience - 30);
            return baseAmount;
        }

        public int CalculateAdditionalCredits(int audience) => 0;
    }
}