using MathSolver.Functions;

namespace MathSolver.States
{
    public class FunctionOrVariableEnteringState : SignedState
    {
        private bool _isFunction;

        public FunctionOrVariableEnteringState()
        {
            Transitions.Add(new Transition("[A-Z]", this));
            Transitions.Add(new Transition(@"[0-9\.]", new SimpleExpressionVariableEnteredState()));
            Transitions.Add(new Transition(@"[+\-/*]", new ComplexExpressionState()));
            Transitions.Add(new Transition(@"\(", new FunctionParametersState()));
        }

        public override bool IsFinalState
        {
            get { return !_isFunction; }
        }

        public override IExpression CreateExpression()
        {
            if (_isFunction)
            {
                FunctionExpression retval = null;

                switch (Buffer.ToUpper())
                {
                    case "RAIZ":
                    case "SQRT":
                        retval = new Root();
                        break;
                    case "E":
                        retval = new E();
                        break;
                    case "PI":
                        retval = new Pi();
                        break;
                    case "LOG":
                        retval = new Log();
                        break;
                    case "SOMA":
                    case "SUM":
                        retval = new Sum();
                        break;
                    case "PRODUTO":
                    case "MUL":
                        retval = new Product();
                        break;
                    case "SEN":
                        retval = new Sen();
                        break;
                    case "COS":
                        retval = new Cos();
                        break;
                    case "TG":
                    case "TAN":
                        retval = new Tan();
                        break;
                    case "EXP":
                        retval = new Pow();
                        break;
                }
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