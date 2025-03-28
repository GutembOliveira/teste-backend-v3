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
    
    }


}