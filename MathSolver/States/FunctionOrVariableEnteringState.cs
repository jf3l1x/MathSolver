using MathSolver.Functions;

namespace MathSolver.States
{
    public class FunctionOrVariableEnteringState : SignedState
    {
        private bool _isFunction;

        public FunctionOrVariableEnteringState()
        {
            Transitions.Add(new Transition("[A-Z]", this));
            Transitions.Add(new Transition(@"[0-9\.]", new SimpleExpressionVariableEnteredState(){FunctionFactory = FunctionFactory}));
            Transitions.Add(new Transition(@"[\!\+\-/*\|&\<\>\=]", new OperatorEnteringState() { FunctionFactory = FunctionFactory }));
            Transitions.Add(new Transition(@"\(", new FunctionParametersState(){FunctionFactory = FunctionFactory}));
        }

        public override bool IsFinalState
        {
            get { return !_isFunction; }
        }

        public override IExpression CreateExpression()
        {
            if (_isFunction)
            {
                var retval = FunctionFactory.CreateFunction(Buffer);
                if (retval != null)
                {
                    retval.Sign = Sign;
                    return retval;
                }
                return NullExpression.Instance;
            }
            return new SimpleExpression(Sign, Buffer, 1, 1);
        }

        public override IState Process(char c)
        {
            if (c == '(')
                _isFunction = true;

            return base.Process(c);
        }
    }
}