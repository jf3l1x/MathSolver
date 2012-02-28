using System;

namespace MathSolver.Functions
{
    public class Pi : FunctionExpression
    {
        public Pi()
            : base(0, 0)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            return AddSign(Math.PI);
        }
    }
}