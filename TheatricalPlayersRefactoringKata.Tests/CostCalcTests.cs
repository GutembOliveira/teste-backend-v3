using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class CostCalcTests{



    [Fact]
    [UseReporter(typeof(DiffReporter))]
    //test to check if perfomance costs are calculating correctly
    public void TestPerfomanceCosts()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, "tragedy"));
        //plays.Add("as-like", new Play("As You Like It", 2670, "comedy"));
        //plays.Add("othello", new Play("Othello", 3560, "tragedy"));
        var perfomance = new Performance("Hamlet",55);
        var custo = perfomance.PerformanceCost(55,"tragedy");
        try{
               Assert.Equal(305,custo);

        }catch(Exception){
            throw new Exception("Falha no teste, valor incorreto");
            }
    }


}