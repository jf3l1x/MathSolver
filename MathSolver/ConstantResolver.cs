namespace MathSolver
{
    public class ConstantResolver : IVariableResolver
    {
        private readonly double _value;

        public ConstantResolver(double value)
        {
            _value = value;
        }

        #region IVariableResolver Members

        public double Resolve(string name)
        {
            return _value;
        }

        #endregion
    }
}