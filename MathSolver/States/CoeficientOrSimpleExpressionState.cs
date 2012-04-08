using System;

namespace MathSolver.States
{
    public class CoeficientOrSimpleExpressionState : SignedState
    {
        public CoeficientOrSimpleExpressionState()
        {
            Transitions.Add(new Transition(@"[0-9\.]", this));
            Transitions.Add(new Transition("[A-Z]", new SimpleExpressionCoeficientEnteredState(){FunctionFactory = FunctionFactory}));
            Transitions.Add(new Transition(@"[\!\+\-/*\|&\<\>\=]", new OperatorEnteringState(){FunctionFactory = FunctionFactory}));
        }

        public double Coeficient
        {
            get { return GetDoubleFromBuffer(); }
        }

        public override bool IsFinalState
        {
            get { return true; }
        }

        public override void Enter(IState from, char c)
        {
            if (Char.IsDigit(c) || c == '.')
                base.Enter(from, c);
        }

        public override IExpression CreateExpression()
        {
            return new SimpleExpression(Sign, "x", Coeficient, 0);
        }
    }
}