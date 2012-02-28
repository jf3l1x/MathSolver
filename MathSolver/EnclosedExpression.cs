namespace MathSolver
{
    public class EnclosedExpression : IExpression
    {
        private readonly Sign _sign;
        private IExpression _expression;


        public EnclosedExpression(Sign sign, IExpression expression)
        {
            _sign = sign;
            _expression = expression;
        }

        public IExpression Expression
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

        #region IExpression Members

        public double Calc(IVariableResolver resolver)
        {
            double retval = _expression.Calc(resolver);
            if (_sign == Sign.Negative)
                retval = retval*-1;
            return retval;
        }

        #endregion
    }
}