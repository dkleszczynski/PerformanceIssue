using PerformanceIssue.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerformanceIssue.Tests
{
    public class TextAnalyserTests
    {
        private TextAnalyser analyser = new TextAnalyser();

        [Fact]
        public void TestSolution_1_ShortInput()
        {
            int outcome = analyser.Solution("KAWA");
            Assert.Equal(16, outcome);
        }
    }
}
