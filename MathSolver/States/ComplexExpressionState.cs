namespace MathSolver.States
{
    public class ComplexExpressionState : CompositeState
    {
        private IExpression _leftSideExpression;
        private Operators _operator;

        public ComplexExpressionState(IExpression leftSideExpression,Operators op)
        {
            _leftSideExpression = leftSideExpression;
            _operator = op;
            Transitions.Add(new Transition(@"[A-Z0-9\.,\+\-/*\|&\>\<\!\=\(\)]", this));
        }
        
        public override void Enter(IState from, char c)
        {
            ContainedState = ContainedState.Process(c);
            base.Enter(from, c);
        }

        public override IExpression CreateExpression()
        {
            IExpression retval = NullExpression.Instance;
            if (ContainedState.IsFinalState)
            {
                retval = new ComplexExpression(_leftSideExpression);
                ((ComplexExpression) retval).AddExpression(ContainedState.CreateExpression(), _operator);
            }
            return retval;
        }
    }
}