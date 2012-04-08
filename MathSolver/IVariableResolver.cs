namespace MathSolver
{
    public interface IVariableResolver
    {
        double Resolve(string name);
        void SetCachedValue(string key, double value);
        double? GetCachedValue(string key);
    }
}