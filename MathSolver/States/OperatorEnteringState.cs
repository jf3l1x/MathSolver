using System.Globalization;

namespace MathSolver.States
{
    public class OperatorEnteringState : BaseState
    {
        private IExpression _leftSideExpression;
        private Operators _operator;
        public OperatorEnteringState()
        {
            _leftSideExpression = NullExpression.Instance;
            _operator = Operators.None;
        }

        public override IState Process(char c)
        {
            bool consumed = false;
            if (c == '|' || c == '&' || c == '=')
            {
                Append(c.ToString(CultureInfo.InvariantCulture));
                consumed = true;
            }
            SetOperator();
            if (_operator == Operators.None)
                return InvalidState.Instance;
            var retval= new ComplexExpressionState(_leftSideExpression, _operator) {FunctionFactory = FunctionFactory};
            if (!consumed)
            {
                retval.Enter(this,c);
            }
            return retval;
        }
        public override bool IsFinalState
        {
            get { return false; }
        }
        private void SetOperator()
        {
            switch (Buffer)
            {
                case "+":
                    _operator = Operators.Sum;
                    break;
                case "-":
                    _operator = Operators.Subtract;
                    break;
                case "/":
                    _operator = Operators.Divide;
                    break;
                case "*":
                    _operator = Operators.Multiply;
                    break;
                case ">":
                    _operator = Operators.Greater;
                    break;
                case ">=":
                    _operator = Operators.GreaterOrEqual;
                    break;
                case "<":
                    _operator = Operators.Lesser;
                    break;
                case "<=":
                    _operator = Operators.LesserOrEqual;
                    break;
                case "==":
                    _operator = Operators.Equals;
                    break;
                case "!=":
                    _operator = Operators.NotEquals;
                    break;
                case "&&":
                    _operator = Operators.And;
                    break;
                case "||":
                    _operator = Operators.Or;
                    break;
            }
        }

        public override void Enter(IState from, char c)
        {
            if (from.IsFinalState)
                _leftSideExpression = from.CreateExpression();
            base.Enter(from, c);
        }
    }
}