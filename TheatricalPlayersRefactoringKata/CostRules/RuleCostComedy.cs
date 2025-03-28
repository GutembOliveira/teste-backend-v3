namespace TheatricalPlayersRefactoringKata;


public class RuleCostComedy : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
                    var value = baseValue;
                    //se comédia
                    if (audience > 20) {
                        value += 100.00 + 5.00 * (audience - 20);
                    }
                    value += 3.00 * audience;
                    return value;
    }
}
