namespace MathSolver
{
    public interface IExpression
    {
        double Calc(IVariableResolver resolver);
    }
}