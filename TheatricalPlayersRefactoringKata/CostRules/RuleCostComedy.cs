namespace TheatricalPlayersRefactoringKata;


public class RuleCostComedy : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
                    var value = baseValue;
                    //se comédia
                    if (audience > 20) {
                        value += 10000 + 500 * (audience - 20);
                    }
                    value += 300 * audience;
                    return value;
    }
}
