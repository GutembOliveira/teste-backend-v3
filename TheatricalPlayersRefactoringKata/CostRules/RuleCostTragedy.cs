namespace TheatricalPlayersRefactoringKata;


public class RuleCostTragedy : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
                var value = baseValue; 
                if (audience > 30) {
                            value += 10.00 * (audience - 30);
                        }
                    return  value;
    }
}
