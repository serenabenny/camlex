﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.SharePoint;

namespace CamlexNET.Interfaces
{
    public interface IAnalyzer
    {
        bool IsValid(LambdaExpression expr);
        IOperation GetOperation(LambdaExpression expr);
    }
}
