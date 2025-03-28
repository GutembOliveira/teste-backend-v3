namespace TheatricalPlayersRefactoringKata;
using System;
public class RuleCreditComedy : IRuleCredit
{
    public override int PlayCredtis(int audience,string playType)
    {
        var playCredits = Math.Max(audience - 30, 0);
        playCredits += (int)Math.Floor((decimal)audience / 5);

        return  playCredits;
    }
}
