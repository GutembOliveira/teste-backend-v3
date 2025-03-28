using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    private string _playId;
    private int _audience;
    private double _playCost;
    private int _playCredtis;
    public double PlayCost { get => _playCost; set => _playCost = value; }
    public int PlayCredtis { get => _playCredtis; set => _playCredtis = value; }
    public string PlayId { get => _playId; set => _playId = value; }
    public int Audience { get => _audience; set => _audience = value; }

    public Performance(string playID, int audience)
    {
        this._playId = playID;
        this._audience = audience;
    }

    public int PerformanceCredits(int audience,string playType){
            string ruleName = $"RuleCredit{playType}"; // Exemplo: "RegraComedia"
            int credits = 0;
            Type? ruleType =  Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .FirstOrDefault(t => t.Name.Equals(ruleName, StringComparison.OrdinalIgnoreCase));
            if (ruleType == null)
            {
                //Caso  a peça não tenha um calculo especifico, o valor será o padrão(numero de linhas/10)
                IRuleCredit regra = (IRuleCredit)Activator.CreateInstance(typeof(RuleCreditDefault));
                credits+= regra.PlayCredtis(audience,playType);

            }else{
                IRuleCredit regra = (IRuleCredit)Activator.CreateInstance(ruleType);
                credits += regra.PlayCredtis(audience,playType);
            }
            this._playCredtis = credits;
            return credits;
    }

    public double PerformanceCost(double baseValue, string playType){

            string ruleName = $"RuleCost{playType.ToLower()}"; // Exemplo: "RegraComedia"
            double ammount = 0;
            Type? ruleType =  Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .FirstOrDefault(t => t.Name.Equals(ruleName, StringComparison.OrdinalIgnoreCase));
            if (ruleType == null)
            {
                //Caso  a peça não tenha um calculo especifico, o valor será o padrão(numero de linhas/10)
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(typeof(RuleCostDefault));
                ammount+= regra.PlayCost(baseValue,this.Audience);

            }else{
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(ruleType)!;
                ammount += regra.PlayCost(baseValue,this.Audience);
            }
            this._playCost = ammount;
            return ammount;
    }

}
