using System;

namespace MathSolver.Functions
{
    public class Root : FunctionExpression
    {
        public Root()
            : base(1, 2)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            if (Parameters.Count == 1)
                return AddSign(Math.Sqrt(GetParameterValue(0, resolver)));
            else
            {
                return AddSign(Math.Pow(GetParameterValue(0, resolver), 1/GetParameterValue(1, resolver)));
            }
        }
        public override string Name
        {
            get { return "Root"; }
        }
    }
}