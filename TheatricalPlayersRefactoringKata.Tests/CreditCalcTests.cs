using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class CreditCalcTests{



    [Fact]
    [UseReporter(typeof(DiffReporter))]
    //test to check if perfomance costs are calculating correctly
    public void TestPerfomanceCredits()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, "tragedy"));
        //plays.Add("as-like", new Play("As You Like It", 2670, "comedy"));
        var perfomance = new Performance("Hamlet",50);
        var creditos = perfomance.PerformanceCredits(perfomance.Audience,"tragedy");

        try{
        Assert.Equal(20,creditos);
        }catch(Exception){
            throw new Exception("Falha no teste, valor incorreto");
            }
    }


}