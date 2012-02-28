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
    }
}