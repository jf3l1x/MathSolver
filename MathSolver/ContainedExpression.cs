using System.Text;

namespace MathSolver
{
    internal class ContainedExpression : IExpression
    {
        private readonly IExpression _expression;
        private readonly Operators _op;

        public ContainedExpression(IExpression expression, Operators op)
        {
            _op = op;
            _expression = expression;
        }

        internal IExpression Expression
        {
            get { return _expression; }
        }

        public Operators Operator
        {
            get { return _op; }
        }

        #region IExpression Members

        public double Calc(IVariableResolver resolver)
        {
            return _expression.Calc(resolver);
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            string op = string.Empty;
            switch (Operator)
            {
                case Operators.Equals:
                    op = "==";
                    break;
                case Operators.NotEquals:
                    op = "!=";
                    break;
                case Operators.Greater:
                    op = ">";
                    break;
                case Operators.Divide:
                    op = "/";
                    break;
                case Operators.Subtract:
                    op = "-";
                    break;
                case Operators.Sum:
                    op = "+";
                    break;
                case Operators.Multiply:
                    op = "*";
                    break;
                case Operators.GreaterOrEqual:
                    op = ">=";
                    break;
                case Operators.Lesser:
                    op = "<";
                    break;
                case Operators.LesserOrEqual:
                    op = "<=";
                    break;
                case Operators.Or:
                    op = "||";
                    break;
                case Operators.And:
                    op = "&&";
                    break;
                
            }
            sb.Append(op);
            sb.Append(" ");
            sb.Append(_expression.ToString());
            return sb.ToString();
        }
    }
}