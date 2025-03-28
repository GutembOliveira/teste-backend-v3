namespace TheatricalPlayersRefactoringKata;


public class RuleCostHistory : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
            var ruleComedy = new RuleCostComedy();
            var ruleTragedy = new RuleCosttragedy();
            var playAmmount=ruleComedy.PlayCost(baseValue,audience)+ruleTragedy.PlayCost(baseValue,audience);
            return playAmmount;
    }
}
