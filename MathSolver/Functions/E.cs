using System;

namespace MathSolver.Functions
{
    public class E : FunctionExpression
    {
        public E()
            : base(0, 0)
        {
        }

        public override double Calc(IVariableResolver resolver)
        {
            return AddSign(Math.E);
        }
        public override string Name
        {
            get { return "E"; }
        }
    }
}