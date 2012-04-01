using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSolver.Functions
{
    public interface IFunctionFactory
    {
        IFunctionExpression CreateFunction(string name);
    }
}
