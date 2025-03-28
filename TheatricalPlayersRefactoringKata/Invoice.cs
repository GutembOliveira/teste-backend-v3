using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;
namespace  TheatricalPlayersRefactoringKata;
public class Invoice
{
    private string _customer;
    private List<Performance> _performances;
    private double _totalCost;
    private int _totalCredits;
    private string invoiceResume;
    public string Customer { get => _customer; set => _customer = value; }
    public List<Performance> Performances { get => _performances; set => _performances = value; }
    public double TotalCost { get => _totalCost; set => _totalCost = value; }
    public int TotalCretids { get => _totalCredits; set => _totalCredits = value; }
    public string InvoiceResume { get => invoiceResume; set => invoiceResume = value; }

    public Invoice(string customer, List<Performance> performance)
    {
        this._customer = customer;
        this._performances = performance;
    }



    public string InvoiceCostText(List<Performance> Performances,Dictionary<string, Play> plays){
        CultureInfo cultureInfo = new CultureInfo("en-US");
        double totalAmount = 0;
        double playAmmount = 0;
        string invoiceText = "";
        foreach(var perf in Performances){
            var play = plays.Where(x=>x.Key==perf.PlayId).FirstOrDefault().Value;
            var baseValue = play.Lines*10;
            if(play.Type=="history"){
            playAmmount=perf.PerformanceCost(baseValue,"comedy")+perf.PerformanceCost(baseValue,"tragedy");
            totalAmount+=playAmmount;
            }else{
            playAmmount=perf.PerformanceCost(baseValue,play.Type);
            totalAmount+=playAmmount;
            }
            invoiceText += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(playAmmount / 100), perf.Audience);
        }

        this._totalCost = totalAmount;
        return invoiceText;
    }

    public int InvoiceCredits(List<Performance> Performances,Dictionary<string, Play> plays){
        CultureInfo cultureInfo = new CultureInfo("en-US");

        int totalCredits = 0;
        foreach(var perf in Performances){
            var play = plays.Where(x=>x.Key==perf.PlayId).FirstOrDefault().Value;
            totalCredits+=perf.PerformanceCredits(perf.Audience,play.Type);
            }
        this._totalCredits = totalCredits;
        return totalCredits;

        }
}

