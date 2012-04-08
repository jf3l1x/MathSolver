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

        public void SetCachedValue(string key, double value)
        {
            
        }

        public double? GetCachedValue(string key)
        {
            return 1;
        }

        #endregion
    }
}