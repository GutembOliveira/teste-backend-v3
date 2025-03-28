namespace TheatricalPlayersRefactoringKata;
using System;

public class RuleCreditDefault : IRuleCredit
{
    public override int PlayCredtis(int audience,string playType)
    {
        var playCredits = Math.Max(audience - 30, 0);
        return  playCredits;
    }
}
