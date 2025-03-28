using System.Collections.Generic;
using System;
namespace  TheatricalPlayersRefactoringKata;
public class Invoice
{
    private string _customer;
    private List<Performance> _performances;

    public string Customer { get => _customer; set => _customer = value; }
    public List<Performance> Performances { get => _performances; set => _performances = value; }

    public Invoice(string customer, List<Performance> performance)
    {
        this._customer = customer;
        this._performances = performance;
    }



    public double InvoiceCost(List<Performance> Performances,Dictionary<string, Play> plays){
        double totalAmount = 0;
        foreach(var perf in Performances){
            string ruleName = $"RuleCost{perf.PlayId}"; // Exemplo: "RegraComedia"
            
            Type? ruleType = Type.GetType(ruleName);
            if (ruleName == null)
            {
                //Caso  a peça não tenha um calculo especifico, o valor será o padrão(numero de linhas/10)
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(typeof(RuleCostDefault));
                //totalAmount+= regra.PlayCost();

            }else{
                var play = plays[perf.PlayId];
                var baseValue = play.Lines/10;
                IRuleCost regra = (IRuleCost)Activator.CreateInstance(ruleType)!;
                if(perf.PlayId=="history"){}
                else
                    totalAmount += regra.PlayCost(baseValue,perf.Audience);
            }
        }
        return totalAmount;
    }

    public double InvoiceCredits(List<Performance> Performances){
        return 0;
    }
}
