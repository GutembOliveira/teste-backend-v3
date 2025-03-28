namespace TheatricalPlayersRefactoringKata;


public  class RuleCostDefault : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
                    return baseValue;
    }
}
