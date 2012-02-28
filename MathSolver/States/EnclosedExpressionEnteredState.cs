namespace MathSolver.States
{
    public class EnclosedExpressionEnteredState : BaseState
    {
        private IExpression _expression;

        public EnclosedExpressionEnteredState()
        {
            Transitions.Add(new Transition(@"[+\-/*]", new ComplexExpressionState()));
            _expression = NullExpression.Instance;
        }

        public EnclosedExpressionEnteredState(IExpression expression) : this()
        {
            Expression = expression;
        }

        public override bool IsFinalState
        {
            get { return true; }
        }

        protected IExpression Expression
        {
            get { return _expression; }
            set
            {
                if (value == null)
                    _expression = NullExpression.Instance;
                else
                    _expression = value;
            }
        }

        public override IExpression CreateExpression()
        {
            return _expression;
        }


        public override void Enter(IState from, char c)
        {
            base.Enter(from, c);
            if (from.IsFinalState)
            {
                Expression = from.CreateExpression();
            }
        }
    }
}