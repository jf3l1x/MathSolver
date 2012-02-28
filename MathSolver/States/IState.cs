using System.Collections.Generic;

namespace MathSolver.States
{
    public interface IState
    {
        bool IsFinalState { get; }
        string Buffer { get; }
        IList<ITransition> Transitions { get; }
        IState Process(char c);
        void Enter(IState from, char c);
        IExpression CreateExpression();
    }
}