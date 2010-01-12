﻿using System;
using System.Linq.Expressions;
using CamlexNET.Impl.Operations.BeginsWith;
using CamlexNET.Interfaces;
using Microsoft.SharePoint;
using NUnit.Framework;
using Rhino.Mocks;

namespace CamlexNET.UnitTests.Operations.BeginsWith
{
    [TestFixture]
    class BeginsWithAnalyzerTests
    {
        [Test]
        public void test_THAT_beginswith_expression_with_string_type_IS_valid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            Expression<Func<SPItem, bool>> expr = x => ((string)x["Count"]).StartsWith("foo");
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void test_THAT_beginswith_expression_with_string_variable_as_indexer_param_IS_valid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);

            string val = "Count";
            Expression<Func<SPItem, bool>> expr = x => ((string)x[val]).StartsWith("foo");
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionWithCustomTextTypeIsValid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            Expression<Func<SPItem, bool>> expr = x => ((DataTypes.Text)x["Count"]).StartsWith("foo");
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionWithCustomNoteTypeIsValid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            Expression<Func<SPItem, bool>> expr = x => ((DataTypes.Note)x["Count"]).StartsWith("foo");
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionWithStringTypeAndVariableIsValid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            var stringVar = "Blah-blah-blah";
            Expression<Func<SPItem, bool>> expr = x => ((string)x["Count"]).StartsWith(stringVar);
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionWithCustomTextTypeAndVariableIsValid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            var stringVar = "Blah-blah-blah";
            Expression<Func<SPItem, bool>> expr = x => ((DataTypes.Text)x["Count"]).StartsWith(stringVar);
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionWithCustomNoteTypeAndVariableIsValid()
        {
            var analyzer = new BeginsWithAnalyzer(null, null);
            var stringVar = "Blah-blah-blah";
            Expression<Func<SPItem, bool>> expr = x => ((DataTypes.Note)x["Count"]).StartsWith(stringVar);
            Assert.That(analyzer.IsValid(expr), Is.True);
        }

        [Test]
        public void TestThatBeginsWithExpressionIsDeterminedProperly()
        {
            // arrange
            Expression<Func<SPItem, bool>> expr = x => ((string)x["Count"]).StartsWith("foo");
            var operandBuilder = MockRepository.GenerateStub<IOperandBuilder>();
            operandBuilder.Stub(b => b.CreateFieldRefOperand(((MethodCallExpression)expr.Body).Object)).Return(null);
            operandBuilder.Stub(b => b.CreateValueOperandForNativeSyntax(((MethodCallExpression)expr.Body).Arguments[0])).Return(null);
            var analyzer = new BeginsWithAnalyzer(null, operandBuilder);

            // act
            var operation = analyzer.GetOperation(expr);

            //assert
            Assert.That(operation, Is.InstanceOf<BeginsWithOperation>());
        }

        [Test]
        public void TestThatBeginsWithExpressionWithStringTypeIsDeterminedProperly()
        {
            // arrange
            Expression<Func<SPItem, bool>> expr = x => ((string)x["Count"]).StartsWith("foo");
            var operandBuilder = MockRepository.GenerateStub<IOperandBuilder>();
            operandBuilder.Stub(b => b.CreateFieldRefOperand(((MethodCallExpression)expr.Body).Object)).Return(null);
            operandBuilder.Stub(b => b.CreateValueOperandForNativeSyntax(((MethodCallExpression)expr.Body).Arguments[0])).Return(null);
            var analyzer = new BeginsWithAnalyzer(null, operandBuilder);

            // act
            var operation = analyzer.GetOperation(expr);

            //assert
            Assert.That(operation, Is.InstanceOf<BeginsWithOperation>());
        }

        [Test]
        public void TestThatBeginsWithExpressionWithCustomNoteTypeIsDeterminedProperly()
        {
            // arrange
            Expression<Func<SPItem, bool>> expr = x => ((DataTypes.Note)x["Count"]).StartsWith("foo");
            var operandBuilder = MockRepository.GenerateStub<IOperandBuilder>();
            operandBuilder.Stub(b => b.CreateFieldRefOperand(((MethodCallExpression)expr.Body).Object)).Return(null);
            operandBuilder.Stub(b => b.CreateValueOperandForNativeSyntax(((MethodCallExpression)expr.Body).Arguments[0])).Return(null);
            var analyzer = new BeginsWithAnalyzer(null, operandBuilder);

            // act
            var operation = analyzer.GetOperation(expr);

            //assert
            Assert.That(operation, Is.InstanceOf<BeginsWithOperation>());
        }
    }
}
