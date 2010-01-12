﻿using System;
using System.Linq.Expressions;
using CamlexNET.Impl.Factories;
using CamlexNET.Impl.Operations.AndAlso;
using CamlexNET.Interfaces;
using Microsoft.SharePoint;
using NUnit.Framework;
using Rhino.Mocks;

namespace CamlexNET.UnitTests.Operations.AndAlso
{
    [TestFixture]
    public class AndAlsoAnalyzerTests
    {
        [Test]
        public void test_THAT_logical_and_expression_IS_valid_expression()
        {
            Expression<Func<SPItem, bool>> expr = x => (string) x["Email"] == "test@example.com" &&
                                                       (int) x["Count1"] == 1;
            var operandBuilder = new OperandBuilder();
            var analyzerFactory = new AnalyzerFactory(operandBuilder, null);
            var analyzer = new AndAlsoAnalyzer(null, analyzerFactory);
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void test_THAT_binary_and_expression_IS_not_valid_expression()
        {
            Expression<Func<SPItem, bool>> expr = x => (string)x["Email"] == "test@example.com" &
                                                       (int)x["Count1"] == 1;
            var operandBuilder = new OperandBuilder();
            var analyzerFactory = new AnalyzerFactory(operandBuilder, null);
            var analyzer = new AndAlsoAnalyzer(null, analyzerFactory);
            Assert.That(analyzer.IsValid(expr), Is.False);
        }

        [Test]
        public void test_THAT_valid_andalso_expression_IS_recognized_successfully()
        {
            // arrange
            var analyzerFactoryStub = MockRepository.GenerateStub<IAnalyzerFactory>();
            var analyzerStub = MockRepository.GenerateStub<IAnalyzer>();
            analyzerFactoryStub.Stub(f => f.Create(null)).Return(analyzerStub).IgnoreArguments();
            analyzerStub.Stub(a => a.IsValid(null)).Return(true).IgnoreArguments();
            var analyzer = new AndAlsoAnalyzer(null, analyzerFactoryStub);


            Expression<Func<SPItem, bool>> expr = x => (string)x["Email"] == "test@example.com" &&
                                                       (int)x["Count1"] == 1;
            // act
            var operation = analyzer.GetOperation(expr);

            // assert
            Assert.That(operation, Is.InstanceOf<AndAlsoOperation>());
        }
    }
}


