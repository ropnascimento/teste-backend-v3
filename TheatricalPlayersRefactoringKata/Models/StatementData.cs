using System.Collections.Generic;
namespace TheatricalPlayersRefactoringKata.Models
{
    public class StatementData
    {
        public string Customer { get; set; }
        public List<PerformanceData> Performances { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalCredits { get; set; }
    }
}