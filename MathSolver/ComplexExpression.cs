using System.Collections.Generic;
using System.Text;

namespace MathSolver
{
    public class ComplexExpression : IExpression
    {
        private readonly List<ContainedExpression> _expressions;

        public ComplexExpression(IExpression leftSideExpression)
        {
            _expressions = new List<ContainedExpression>();
            AddExpression(leftSideExpression, Operators.None);
        }

        #region IExpression Members

        public double Calc(IVariableResolver resolver)
        {
            double retval = 0;
            for (int i = 0; i < _expressions.Count; i++)
            {
                bool left;
                bool right;
                switch (_expressions[i].Operator)
                {
                    case Operators.None:
                        retval = _expressions[i].Calc(resolver);
                        break;
                    case Operators.Divide:
                        retval = retval/_expressions[i].Calc(resolver);
                        break;
                    case Operators.Multiply:
                        retval = retval * _expressions[i].Calc(resolver);
                        break;
                    case Operators.Subtract:
                        retval = retval - _expressions[i].Calc(resolver);
                        break;
                    case Operators.Sum:
                        retval = retval + _expressions[i].Calc(resolver);
                        break;
                    case Operators.Equals:
                        if (retval.Equals(_expressions[i].Calc(resolver)))
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.NotEquals:
                        if (!retval.Equals(_expressions[i].Calc(resolver)))
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.Greater:
                        if (retval>_expressions[i].Calc(resolver))
                        {
                            retval=1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.GreaterOrEqual:
                        if (retval >= _expressions[i].Calc(resolver))
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.LesserOrEqual:
                        if (retval <= _expressions[i].Calc(resolver))
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.Lesser:
                        if (retval < _expressions[i].Calc(resolver))
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.And:
                        left = retval > 0;
                        right = _expressions[i].Calc(resolver)>0;
                        if (left && right)
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;
                    case Operators.Or:
                        left = retval > 0;
                        right = _expressions[i].Calc(resolver) > 0;
                        if (left || right)
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = 0;
                        }
                        break;



                }
            }
            return retval;
        }

        #endregion

        public void AddExpression(IExpression expression, Operators op)
        {
            if (!AddFromComplexExpression(expression, op))
            {
                if ((op != Operators.Sum && op != Operators.Subtract ) && _expressions.Count > 0)
                {
                    ReplaceExpression(expression, op);
                }
                else
                    _expressions.Add(new ContainedExpression(expression, op));
            }
        }

        /// <summary>
        /// Substitui uma expressao contida por uma contendo uma complexa. com isso as operações de divisao e multiplicacao tem maior prioridade sobre as de soma e subtracao
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="op"></param>
        private void ReplaceExpression(IExpression expression, Operators op)
        {
            ContainedExpression left = _expressions[_expressions.Count - 1];
            _expressions.Remove(left);
            var c = new ComplexExpression(left.Expression);
            c._expressions.Add(new ContainedExpression(expression, op));
            _expressions.Add(new ContainedExpression(c, left.Operator));
        }

        private bool AddFromComplexExpression(IExpression expression, Operators op)
        {
            bool retval = false;
            var c = expression as ComplexExpression;
            if (c != null)
            {
                if (c._expressions.Count > 0)
                {
                    _expressions.Add(new ContainedExpression(c._expressions[0].Expression, op));
                }
                for (int i = 1; i < c._expressions.Count; i++)
                {
                    _expressions.Add(c._expressions[i]);
                }
                retval = true;
            }
            return retval;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var containedExpression in _expressions)
            {
                sb.Append(containedExpression.ToString());
            }
            return sb.ToString();
        }
    }
}