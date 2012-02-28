namespace MathSolver
{
    public interface ITokenParser
    {
        IExpression Parse(string text);
    }
}