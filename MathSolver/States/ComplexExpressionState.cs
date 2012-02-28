namespace MathSolver.States
{
    public class ComplexExpressionState : CompositeState
    {
        private IExpression _leftSideExpression;
        private Operators _operator;

        public ComplexExpressionState()
        {
            _leftSideExpression = NullExpression.Instance;
            _operator = Operators.Sum;
            Transitions.Add(new Transition(@"[A-Z0-9\.,+\-/*()]", this));
        }

        public override void Enter(IState from, char c)
        {
            if (from != this)
            {
                switch (c)
                {
                    case '+':
                        _operator = Operators.Sum;
                        break;
                    case '-':
                        _operator = Operators.Subtract;
                        break;
                    case '/':
                        _operator = Operators.Divide;
                        break;
                    case '*':
                        _operator = Operators.Multiply;
                        break;
                    
                }
                if (from.IsFinalState)
                    _leftSideExpression = from.CreateExpression();
            }
            else
            {
                ContainedState = ContainedState.Process(c);
            }
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