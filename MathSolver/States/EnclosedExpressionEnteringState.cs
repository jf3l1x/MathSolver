using System;

namespace MathSolver.States
{
    public class EnclosedExpressionEnteringState : CompositeState
    {
        private int _parenthesisCount;

        public EnclosedExpressionEnteringState()
        {
            Transitions.Add(new Transition(@"[A-Z0-9,\.\+\-/*\(]", this));
        }

        public override bool IsFinalState
        {
            get { return false; }
        }

        protected virtual IState CreateNextStateForEndingParenthesis()
        {
            if (ContainedState.IsFinalState)
                return
                    new EnclosedExpressionEnteredState(new EnclosedExpression(Sign, ContainedState.CreateExpression()));
            return InvalidState.Instance;
        }

        public override IState Process(char c)
        {
            IState retval = base.Process(c);
            if (c == ')')
            {
                retval = this;
                retval.Enter(this, c);
                _parenthesisCount--;
            }

            if (_parenthesisCount == 0)
                retval = CreateNextStateForEndingParenthesis();

            else
            {
                ContainedState = ContainedState.Process(c);
            }
            return retval;
        }

        public override IExpression CreateExpression()
        {
            throw new NotImplementedException();
        }

        private void CheckParenthesisOpening(char c)
        {
            if (c == '(')
            {
                _parenthesisCount++;
            }
        }

        public override void Enter(IState from, char c)
        {
            base.Enter(from, c);
            CheckParenthesisOpening(c);
        }
    }
}