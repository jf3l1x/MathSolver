using System;
using MathSolver.Functions;

namespace MathSolver.States
{
    public class FunctionEnteredState : EnclosedExpressionEnteredState
    {
        public FunctionEnteredState()
        {
        }

        public FunctionEnteredState(FunctionExpression expression)
            : base(expression)
        {
        }

        public override void Enter(IState from, char c)
        {
            base.Enter(from, c);
            if (!(Expression is FunctionExpression))
            {
                throw new InvalidOperationException();
            }
        }
    }
}