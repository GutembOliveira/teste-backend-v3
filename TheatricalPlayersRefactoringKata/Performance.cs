using System.Collections.Generic;
using System;

namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    private string _playId;
    private int _audience;

    public string PlayId { get => _playId; set => _playId = value; }
    public int Audience { get => _audience; set => _audience = value; }

    public Performance(string playID, int audience)
    {
        this._playId = playID;
        this._audience = audience;
    }

    public double PerformanceCredits(int audience){
        
        return 0;
    }

    public double PerformanceCost(double baseValue){

            string ruleName = $"RuleCost{this.PlayId}"; // Exemplo: "RegraComedia"
            double ammount = 0;
            Type? ruleType = Type.GetType(ruleName);
            if (ruleName == null)
            {
                //Caso  a peça não tenha um calculo especifico, o valor será o padrão(numero de linhas/10)
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(typeof(RuleCostDefault));
                ammount+= regra.PlayCost(baseValue,this.Audience);

            }else{
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(ruleType)!;
                if(this.PlayId=="history"){}
                else
                    ammount += regra.PlayCost(baseValue,this.Audience);
            }


        return 0;
    }

}
