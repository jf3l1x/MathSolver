namespace MathSolver.States
{
    public class SimpleExpressionCoeficientEnteredState : BaseState
    {
        protected IExpression _expression;

        public SimpleExpressionCoeficientEnteredState()
        {
            CreateTransitions();
            _expression = null;
        }

        public override bool IsFinalState
        {
            get { return true; }
        }

        protected virtual void CreateTransitions()
        {
            Transitions.Add(new Transition("[A-Z]", this));
            Transitions.Add(new Transition(@"[0-9\.]", new SimpleExpressionVariableEnteredState(){FunctionFactory = FunctionFactory}));
            Transitions.Add(new Transition(@"[\!\+\-/*\|&\<\>\=]", new OperatorEnteringState() { FunctionFactory = FunctionFactory }));
        }

        public override void Enter(IState from, char c)
        {
            if (from != this)
            {
                _expression = from.CreateExpression();
            }
            base.Enter(from, c);
        }

        public override IExpression CreateExpression()
        {
            var s = _expression as SimpleExpression ?? new SimpleExpression(Sign.Positive, "x", 1, 1);
            SetExpressionData(s);
            return s;
        }

        protected virtual void SetExpressionData(SimpleExpression expression)
        {
            expression.Variable = Buffer;
            expression.Exponent = 1;
        }
    }
}