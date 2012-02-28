namespace MathSolver
{
    public class NullExpression : IExpression
    {
        private static readonly NullExpression _instance = new NullExpression();

        private NullExpression()
        {
        }

        public static NullExpression Instance
        {
            get { return _instance; }
        }

        #region IExpression Members

        public double Calc(IVariableResolver variableValue)
        {
            return 0;
        }

        #endregion
    }
}