using System;

namespace MathSolver.Functions
{
    public class Tan : FunctionExpression
    {
        public Tan()
            : base(1, 1)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            return AddSign(Math.Tan(GetParameterValue(0, resolver)));
        }
    }
}