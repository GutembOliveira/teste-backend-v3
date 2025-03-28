namespace TheatricalPlayersRefactoringKata;

public abstract class IRuleCost
{
    private string _playType;
    private int _audience;
    public string PlayType { get => _playType; set => _playType = value; }
   
public abstract double PlayCost(double baseValue,int audience);
}
