using System;

namespace MathSolver.Functions
{
    public class Pow : FunctionExpression
    {
        public Pow()
            : base(2, 2)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            return AddSign(Math.Pow(GetParameterValue(0, resolver), GetParameterValue(1, resolver)));
        }
    }
}