using System;
using MathSolver.Functions;

namespace MathSolver.States
{
    public class FunctionParametersState : EnclosedExpressionEnteringState
    {
        private FunctionExpression _expression;

        public override bool IsFinalState
        {
            get { return false; }
        }

        protected override IState CreateNextStateForEndingParenthesis()
        {
            if (ContainedState.IsFinalState)
            {
                _expression.AddParameter(ContainedState.CreateExpression());
            }
            else
            {
                if (ContainedState.GetType() != typeof (InitialState))
                    return InvalidState.Instance;
            }
            return new FunctionEnteredState(_expression){FunctionFactory = FunctionFactory};
        }

        public override IState Process(char c)
        {
            if (_expression == null)
            {
                return InvalidState.Instance;
            }
            if (c == ',')
            {
                if (ContainedState.IsFinalState)
                {
                    _expression.AddParameter(ContainedState.CreateExpression());
                    ContainedState = new InitialState(){FunctionFactory = FunctionFactory};
                    Append(c.ToString());
                    return this;
                }
            }
            return base.Process(c);
        }

        public override void Enter(IState from, char c)
        {
            if (from != this)
            {
                try
                {
                    _expression = from.CreateExpression() as FunctionExpression;
                }
                catch (NotImplementedException)
                {
                    throw new InvalidOperationException();
                }
            }
            base.Enter(from, c);
        }

        public override IExpression CreateExpression()
        {
            return _expression;
        }
    }
}