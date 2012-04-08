using System;

namespace MathSolver.Functions
{
    public class Log : FunctionExpression
    {
        public Log()
            : base(2, 2)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            return AddSign(Math.Log(GetParameterValue(0, resolver), GetParameterValue(1, resolver)));
        }
        public override string Name
        {
            get { return "Log"; }
        }
    }
}