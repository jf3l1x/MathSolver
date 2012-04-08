using System;

namespace MathSolver.Functions
{
    public class Cos : FunctionExpression
    {
        public Cos()
            : base(1, 1)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            return AddSign(Math.Cos(GetParameterValue(0, resolver)));
        }
        public override string Name
        {
            get { return "Cos"; }
        }
    }
}