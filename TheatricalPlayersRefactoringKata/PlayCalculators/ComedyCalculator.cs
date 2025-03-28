using System;
namespace TheatricalPlayersRefactoringKata.PlayCalculators
{

    public class ComedyCalculator : IPlayCalculator
    {
        public decimal CalculateAmount(int lines, int audience)
        {
            decimal baseAmount = (decimal)lines / 10;
            baseAmount += 3 * audience;
            if (audience > 20)
                baseAmount += 100 + 5 * (audience - 20);
            return baseAmount;
        }

        public int CalculateAdditionalCredits(int audience) => (int)Math.Floor((decimal)audience / 5);
    }
}