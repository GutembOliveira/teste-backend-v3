namespace TheatricalPlayersRefactoringKata;


public class RuleCosttragedy : IRuleCost
{
    public override double PlayCost(double baseValue,int audience)
    {
                var value = baseValue; 
                if (audience > 30) {
                            value += 1000   * (audience - 30);
                        }
                    return  value;
    }
}
