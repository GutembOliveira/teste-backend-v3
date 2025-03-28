namespace TheatricalPlayersRefactoringKata;
using System;
public class RuleCreditComedy : IRuleCredit
{
    public override int PlayCredtis(int audience,string playType)
    {
        var volumeCredits = Math.Max(audience - 30, 0);
        if ("comedy" == playType) volumeCredits += (int)Math.Floor((decimal)audience / 5);

        return  volumeCredits;
    }
}
