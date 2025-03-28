namespace TheatricalPlayersRefactoringKata;
using System;

public class RuleCreditDefault : IRuleCredit
{
    public override int PlayCredtis(int audience,string playType)
    {
        var volumeCredits = Math.Max(audience - 30, 0);
        return  volumeCredits;
    }
}
