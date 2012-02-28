namespace MathSolver.States
{
    public interface ITransition
    {
        IState NextState { get; }
        string SimbolsRegex { get; }
        bool Match(char c);
    }
}