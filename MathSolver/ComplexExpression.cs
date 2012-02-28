using System.Collections.Generic;

namespace MathSolver
{
    public class ComplexExpression : IExpression
    {
        private readonly List<ContainedExpression> _expressions;

        public ComplexExpression(IExpression leftSideExpression)
        {
            _expressions = new List<ContainedExpression>();
            AddExpression(leftSideExpression, Operators.Sum);
        }

        #region IExpression Members

        public double Calc(IVariableResolver resolver)
        {
            double retval = 0;
            for (int i = 0; i < _expressions.Count; i++)
            {
                switch (_expressions[i].Operator)
                {
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
                }
            }
            return retval;
        }

        #endregion

        public void AddExpression(IExpression expression, Operators op)
        {
            if (!AddFromComplexExpression(expression, op))
            {
                if ((op == Operators.Multiply || op == Operators.Divide) && _expressions.Count > 0)
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
    }
}