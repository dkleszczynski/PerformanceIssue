using PerformanceIssue.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerformanceIssue.Tests
{
    public class TextAnalyserTests
    {
        private const int LargestSize = (int) 1E5;
        private TextAnalyser analyser = new TextAnalyser();
        
        [Theory]
        [InlineData("KAWA", 16)]
        [InlineData("SCHOLARSHIP", 260)]
        [InlineData("INCOMPREHENSIBILITIES", 1152)]
        [InlineData("AAAAAAAAAA", 10)]
        public void FirstSolution_ReturnCorrectCount_IfCorrectInput(string input, int expected)
        {
            int outcome = analyser.Solution(input);
            Assert.Equal(expected, outcome);
        }

        [Fact]
        public void FirstSolution_ValidationFail_NullInput()
        {
            int outcome = analyser.Solution(null);
            Assert.Equal(-1, outcome);
        }
                
        [Theory]
        [InlineData("FevEr")]
        [InlineData("ABRFS!")]
        [InlineData("BARSF DFG")]
        [InlineData("  BRESAD   ")]
        public void FirstSolution_ValidationFail_IncorrectCharsInInput(string input)
        {
            int outcome = analyser.Solution(input);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("KOT")]
        public void FirstSolution_ValidationFail_TooShortInput(string input)
        {
            int outcome = analyser.Solution(input);
            Assert.Equal(-1, outcome);
        }

        [Fact]
        public void FirstSolution_ValidationFail_TooLongInput()
        {
            string input = new string('A', LargestSize + 1);
            int outcome = analyser.Solution(input);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("KAWA", 16)]
        [InlineData("SCHOLARSHIP", 260)]
        [InlineData("INCOMPREHENSIBILITIES", 1152)]
        [InlineData("AAAAAAAAAA", 10)]
        public void SolutionImproved_ReturnCorrectCount_CorrectInput(string input, int expected)
        {
            int outcome = analyser.SolutionImproved(input);
            Assert.Equal(expected, outcome);
        }

        [Fact]
        public void SolutionImproved_ValidationFail_NullInput()
        {
            int outcome = analyser.SolutionImproved(null);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("FevEr")]
        [InlineData("ABRFS!")]
        [InlineData("BARSF DFG")]
        [InlineData("  BRESAD   ")]
        public void SolutionImproved_ValidationFail_IncorrectCharsInInput(string input)
        {
            int outcome = analyser.SolutionImproved(input);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("KOT")]
        public void SolutionImproved_ValidationFail_TooShortInput(string input)
        {
            int outcome = analyser.SolutionImproved(input);
            Assert.Equal(-1, outcome);
        }

        [Fact]
        public void SolutionImproved_ValidationFail_TooLongInput()
        {
            string input = new string('A', LargestSize + 1);
            int outcome = analyser.SolutionImproved(input);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("KAWA", 16)]
        [InlineData("SCHOLARSHIP", 260)]
        [InlineData("INCOMPREHENSIBILITIES", 1152)]
        [InlineData("AAAAAAAAAA", 10)]
        public void SolutionMultiThread_ReturnCorrectCount_CorrectInput(string input, int expected)
        {
            int outcome = analyser.SolutionMultiThread(input);
            Assert.Equal(expected, outcome);
        }

        [Fact]
        public void SolutionMultiThread_ValidationFail_NullInput()
        {
            int outcome = analyser.SolutionMultiThread(null);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("FevEr")]
        [InlineData("ABRFS!")]
        [InlineData("BARSF DFG")]
        [InlineData("  BRESAD   ")]
        public void SolutionMultiThread_ValidationFail_IncorrectCharsInInput(string input)
        {
            int outcome = analyser.SolutionMultiThread(input);
            Assert.Equal(-1, outcome);
        }

        [Theory]
        [InlineData("KOT")]
        public void SolutionMultiThread_ValidationFail_TooShortInput(string input)
        {
            int outcome = analyser.SolutionMultiThread(input);
            Assert.Equal(-1, outcome);
        }

        [Fact]
        public void SolutionMultiThread_ValidationFail_TooLongInput()
        {
            string input = new string('A', LargestSize + 1);
            int outcome = analyser.SolutionMultiThread(input);
            Assert.Equal(-1, outcome);
        }
    }
}

