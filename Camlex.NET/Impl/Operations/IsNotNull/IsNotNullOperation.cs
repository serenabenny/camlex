﻿using System.Xml.Linq;
using CamlexNET.Impl.Factories;
using CamlexNET.Interfaces;

namespace CamlexNET.Impl.Operations.IsNotNull
{
    public class IsNotNullOperation : UnaryOperationBase
    {
        public IsNotNullOperation(IOperationResultBuilder operationResultBuilder,
            IOperand fieldRefOperand)
            : base(operationResultBuilder, fieldRefOperand)
        {
        }

        public override IOperationResult ToResult()
        {
            var result = new XElement(Tags.IsNotNull,
                             this.fieldRefOperand.ToCaml());
            return this.operationResultBuilder.CreateResult(result);
        }
    }
}


