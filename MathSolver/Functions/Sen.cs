using System;

namespace MathSolver.Functions
{
    public class Sen : FunctionExpression
    {
        public Sen()
            : base(1, 1)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            return AddSign(Math.Sin(GetParameterValue(0, resolver)));
        }
    }
}