﻿using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class GroupingTests
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing",
            MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose001_ExpressionException()
        {
            _func.Function = "{{1+2}";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing",
            MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose002_ExpressionException()
        {
            _func.Function = "{1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing",
            MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen001_ExpressionException()
        {
            _func.Function = "1+2}";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing",
            MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen002_ExpressionException()
        {
            _func.Function = "}{1+2}";
        }

        [Test]
        public void Grouping_NestedParens_CorrectValue()
        {
            //_func.Function = @"if ((a >= 1 || a <= 2) && b >= 3) { 1 } else { 2 } ";
            _func.Function = @"((1+2)*3)";
            Assert.AreEqual(9, _func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing",
            MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose001_ExpressionException()
        {
            _func.Function = "((1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing",
            MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose002_ExpressionException()
        {
            _func.Function = "(1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing",
            MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen001_ExpressionException()
        {
            _func.Function = "1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing",
            MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen002_ExpressionException()
        {
            _func.Function = ")(1+2)";
        }

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingClose001_ExpressionException()
        //{
        //    func.Function = "[[1+2]";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingClose002_ExpressionException()
        //{
        //    func.Function = "[1+2";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingOpen001_ExpressionException()
        //{
        //    func.Function = "1+2]";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingOpen002_ExpressionException()
        //{
        //    func.Function = "][1+2]";
    }
}
