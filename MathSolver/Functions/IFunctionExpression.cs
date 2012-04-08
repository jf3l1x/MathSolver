namespace MathSolver.Functions
{
    public interface IFunctionExpression : IExpression
    {
        int MinParameters { get; set; }
        int MaxParameters { get; set; }
        Sign Sign { get; set; }
        string Name { get; }
    }
}